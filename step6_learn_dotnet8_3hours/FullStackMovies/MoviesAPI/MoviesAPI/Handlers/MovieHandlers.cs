using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Entities;

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
}
