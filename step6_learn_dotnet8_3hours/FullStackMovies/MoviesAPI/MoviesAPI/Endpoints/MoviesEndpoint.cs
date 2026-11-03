using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Handlers;

namespace MoviesAPI.Endpoints;

public static class MoviesEndpoint
{
    //Extension method
    //means extend the WebApplication type with those methods
    public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
    {
        //.WithParameterValidation() is from MinimalApis.Extensions pkg!
        RouteGroupBuilder group = app.MapGroup("movies").WithParameterValidation();

        //create
        //POST /movies
        group.MapPost("/", MovieHandlers.PostMovie);

        //read
        //GET /movies
        //GET /movies?genreId=5
        group.MapGet("/", MovieHandlers.GetMovies);

        //read
        //GET /movies/{id}
        //the route name i.e.(.WithName() ) is needed for the post requests to use and find created records and return it
        group.MapGet("/{id:int}", MovieHandlers.GetMovieById).WithName("GetMovieById");

        //update
        //PUT /movies/{id}
        group.MapPut("/{id:int}", MovieHandlers.UpdateMovie);


        //delete
        //DELETE /movies/{id}
        group.MapDelete("/{id:int}", MovieHandlers.DeleteMovie);

        return group;
    }
}


