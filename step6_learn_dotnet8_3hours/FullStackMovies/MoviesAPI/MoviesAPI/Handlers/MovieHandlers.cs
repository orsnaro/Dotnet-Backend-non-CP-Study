using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Entities;
using MoviesAPI.DTOs.Movies;

namespace MoviesAPI.Handlers;


//why static ? cuz all we need will be passed via method parameters so no need to create class instances or object each time i want to use the method!
public static class MovieHandlers
{
    //cuz this handlers is async operations so its return must be wrapped in Task< >
    //why IResult return then? the http request response result in asp.net core is of type IResult
    //Note: it could be other types like List<Movie> that  asp.net auto resolve it to IResult also

    //GET /movies
    public static async Task<IResult> GetMovies(MovieContext dbContext)
    {
        List<Movie>  movies = await dbContext.Movies.Include("Genre").ToListAsync();

         if (movies.Count == 0) { return Results.NotFound(); }

        IResult result = Results.Ok(movies);

        return result;
    }

    //GET /movies/{id}
    public static async Task<IResult> GetMovieById(MovieContext dbContext, int id)
    {
        Movie? movie = await dbContext.Movies.Include("Genre").FirstOrDefaultAsync(movie => movie.Id == id);

        if (movie is null){return Results.NotFound();}

        IResult result = Results.Ok(movie);

        return result;
    }

    //POST /movies
    public static async Task<IResult> PostMovies(Movie newMovie, MovieContext dbContext){

        var tmpGenre = await dbContext.Genres.FindAsync(newMovie.GenreId); //better than first or firstordefault when were searching using primary key
        if (tmpGenre is null) return Results.BadRequest("Invalid GenreId");
        newMovie.Genre = tmpGenre;

        await dbContext.Movies.AddAsync(newMovie);
        await dbContext.SaveChangesAsync();

        var responseDto = new MovieResponseDto(newMovie.Id, newMovie.Name, newMovie.GenreId);
        var idDto = new MovieIdDto(newMovie.Id);

        return Results.CreatedAtRoute("GetMovieById", idDto, responseDto);
        //incoming post request didnt provide Id and we didnt return Id from DB how newMovie.Id knows the next right Id?
        //ans: ef core auto updates it after SaveChangesAsync() gets the id from db and puts it in newMovie.Id
    }
}
