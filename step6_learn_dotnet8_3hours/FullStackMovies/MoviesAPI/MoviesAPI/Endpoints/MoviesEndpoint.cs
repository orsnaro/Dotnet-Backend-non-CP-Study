using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Handlers;

namespace MoviesAPI.Endpoints;

public static class MoviesEndpoint
{
    //Extension method
    public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app) //means extend the WebApplication type with those methods !
    {
        RouteGroupBuilder group = app.MapGroup("movies").WithParameterValidation();

        //GET /movies
        group.MapGet("/", MovieHandlers.GetMovies);

        //GET /movies/{ID}
        //the route name i.e.(.WithName() ) is needed for the post requests to use and find created records and return it
        group.MapGet("/{id}", MovieHandlers.GetMovieById).WithName("GetMovieById");

        //POST /movies
        group.MapPost("/", MovieHandlers.PostMovies);

        return group;
    }
}


