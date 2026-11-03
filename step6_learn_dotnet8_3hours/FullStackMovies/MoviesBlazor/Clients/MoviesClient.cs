using Movies.Contracts.DTOs;

namespace MoviesBlazor.Clients;
public class MoviesClient(HttpClient httpClient)
{
    public async Task<List<MovieDto>> GetMoviesAsync()
    {
        //here "movies" is the request uri
        //(the backend api base-url is configured on frontend entry point at DI step of this client)
        List<MovieDto> movies = await httpClient.GetFromJsonAsync<List<MovieDto>>("movies") ?? [];

        return movies;
    }
}
