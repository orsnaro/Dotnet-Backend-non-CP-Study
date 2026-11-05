using Movies.Contracts.DTOs;

namespace MoviesBlazor.Clients;

public class GenresClient(HttpClient httpClient)
{
    public async Task<List<GenreDto>> GetGenresAsync()
    {
        List<GenreDto> genres = await httpClient.GetFromJsonAsync<List<GenreDto>>("genres") ?? [];
        return genres;
    }
}
