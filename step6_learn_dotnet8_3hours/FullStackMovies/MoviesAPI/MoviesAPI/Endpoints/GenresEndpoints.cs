
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Handlers;

namespace MoviesAPI.Endpoints;

public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("genres").WithParameterValidation();

        //read
        //GET /genres
        group.MapGet("/", GenreHandlers.GetGenres);


        return group;
    }
}
