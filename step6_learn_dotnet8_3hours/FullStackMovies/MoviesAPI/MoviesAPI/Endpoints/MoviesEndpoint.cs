using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Handlers;

namespace MoviesAPI.Endpoints;

public static class MoviesEndpoint
{
    //Extension method
    public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app) //means extend the WebApplication type with those methods !
    {
        RouteGroupBuilder group = app.MapGroup("movies");

        //GET /movies
        group.MapGet("/", MovieHandlers.GetMovies);

        //GET /movies/{ID}
        group.MapGet("/{id}", MovieHandlers.GetMovieById);

        return group;
    }
}


