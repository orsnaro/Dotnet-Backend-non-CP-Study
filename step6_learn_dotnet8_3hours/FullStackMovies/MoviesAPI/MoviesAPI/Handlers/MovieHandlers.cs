using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Entities;
using Movies.Contracts.DTOs;

namespace MoviesAPI.Handlers;


//why static ? cuz all we need will be passed via method parameters so no need to create class instances or object each time i want to use the method!
public static class MovieHandlers
{
    //cuz this handlers is async operations so its return must be wrapped in Task< >
    //why IResult return then? the http request response result in asp.net core is of type IResult
    //Note: it could be other types like List<Movie> that  asp.net auto resolve it to IResult also

    //POST /movies
    public static async Task<IResult> PostMovie(Movie newMovie, MovieContext dbContext){

        var tmpGenre = await dbContext.Genres.FindAsync(newMovie.GenreId); //better than first or firstordefault when were searching using primary key
        if (tmpGenre is null) {return Results.BadRequest("Invalid GenreId");}
        newMovie.Genre = tmpGenre;

        await dbContext.Movies.AddAsync(newMovie);
        await dbContext.SaveChangesAsync();

        var responseDto = new CreateMovieResponseDto(newMovie.Id, newMovie.Name, newMovie.GenreId);
        var idDto = new MovieIdDto(newMovie.Id);

        return Results.CreatedAtRoute("GetMovieById", idDto, responseDto);
        //incoming post request didnt provide Id and we didnt return Id from DB how newMovie.Id knows the next right Id?
        //ans: ef core auto updates it after SaveChangesAsync() gets the id from db and puts it in newMovie.Id
    }


    //GET /movies
    //GET /moveis?genreId=5
    public static async Task<IResult> GetMovies(int? genreId, MovieContext dbContext)

    {

        //on obsidian notes we speak on what is IQueryable<> and .AsNoTracking() method and EF lazy Execution!
        IQueryable<Movie> moviesQuery = dbContext.Movies.AsNoTracking().Include(movie => movie.Genre);


        //check for filters and apply them
        if (genreId is not null) { moviesQuery = moviesQuery.Where(movie => movie.GenreId == genreId); }


        //just before you get them from db project them to MovieDtos (only expose from db entity what we need!)
        //(projection produces new IQueryable<> type!)
        IQueryable<MovieDto>  movieDtosQuery =  moviesQuery
                                                    .Select(movie => new MovieDto
                                                    {
                                                        Id = movie.Id,
                                                        Name = movie.Name,
                                                        Price = movie.Price,
                                                        GenreName = movie.Genre != null ? movie.Genre.Name : null,
                                                        GenreId = genreId,
                                                        Director = movie.Director,
                                                        ReleaseDate = movie.ReleaseDate
                                                    });

        List<MovieDto> movies = [];
        try
        {
            //here EF core will lazy actually exec SQL and convert to list
            movies = await movieDtosQuery.ToListAsync();
        }
        catch(Exception ex)
        {
           Console.Error.WriteLine($"Could not do a movies query: {ex.Message}");
           return Results.Problem();
        }

        if (movies.Count == 0) { return Results.NotFound();}

        IResult result = Results.Ok(movies);

        return result;
    }


    //GET /movies/{id}
    public static async Task<IResult> GetMovieById(MovieContext dbContext, int id)
    {
        Movie? movie = await dbContext.Movies
                                .AsNoTracking()
                                .Include("Genre")
                                .FirstOrDefaultAsync(movie => movie.Id == id);

        if (movie is null){return Results.NotFound();}

        IResult result = Results.Ok(movie);

        return result;
    }


    //PUT /movies/{id}
    public static async Task<IResult> UpdateMovie(int Id, Movie updateMovie, MovieContext dbContext)
    {
        //get the movie by id from the db
        var oldMovie = await dbContext.Movies.FindAsync(Id);

        //check if not foud return http 404
        if (oldMovie is null) { return Results.NotFound($"Could Not Find a movie with this id {Id}"); }

        //if found update fields that needs update (needed to make price and raleasedate nullable!)
        if (updateMovie.Name is not null) { oldMovie.Name = updateMovie.Name; }
        if (updateMovie.Director is not null) { oldMovie.Director = updateMovie.Director; }
        if (updateMovie.Price is not null) { oldMovie.Price = updateMovie.Price; }
        if (updateMovie.ReleaseDate is not null) { oldMovie.ReleaseDate = updateMovie.ReleaseDate; }
        if (updateMovie.GenreId is not null) { oldMovie.GenreId = updateMovie.GenreId; oldMovie.Genre = await dbContext.Genres.FindAsync(updateMovie.GenreId); }

        //send update to db
        dbContext.Update<Movie>(oldMovie);

        //save updates (commit)
        await dbContext.SaveChangesAsync();


        return Results.NoContent();
    }


    // DELETE /movies/{id}
    public static async Task<IResult> DeleteMovie(int Id, MovieContext dbContext)
    {
        //get the movie by id from the db
        var toDeleteMovie = await dbContext.Movies.FindAsync(Id);

        //check if not foud return err http 404
        if (toDeleteMovie is null) { return Results.NotFound($"Could Not Find a movie with this id {Id}"); }

        dbContext.Movies.Remove(toDeleteMovie);

        await dbContext.SaveChangesAsync();


        return Results.NoContent();

    }
}
