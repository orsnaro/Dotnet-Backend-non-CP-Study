using Microsoft.EntityFrameworkCore;
using MoviesAPI.Data;
using MoviesAPI.Entities;
using Movies.Contracts.DTOs;




namespace MoviesAPI.Handlers;
public static class GenreHandlers
{
    public static async Task<IResult> GetGenres(MovieContext dbContext)
    {
        List<GenreDto> genres = [];

        try{
            genres = await dbContext.Genres
                            .AsNoTracking()
                            .Select(genre => new GenreDto
                            {
                                Id = genre.Id,
                                Name = genre.Name
                            })
                            .ToListAsync();
        }
        catch (Exception ex)
        {
            string err = $"Could not get Genres: {ex}";
            Console.Error.WriteLine(err);
            return Results.Problem(err);
        }

        if (genres.Count == 0) { return Results.NotFound();}

        return Results.Ok(genres);
    }

}
