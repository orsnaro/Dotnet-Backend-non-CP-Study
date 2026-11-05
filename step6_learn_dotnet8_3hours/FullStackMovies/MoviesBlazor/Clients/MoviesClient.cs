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

    public async Task<MovieDto> GetMovieByIdAsync(int id)
    {
        MovieDto movie = await httpClient.GetFromJsonAsync<MovieDto>($"movies/{id}") ?? throw new Exception("Could not find movie");
        return movie;
    }

    public async Task AddMovieAsync(CreateMovieDto movie)
    {
        await httpClient.PostAsJsonAsync("movies", movie);
    }


    public async Task UpdateMovieAsync(int id, UpdateMovieDto movie)
    {
        await httpClient.PutAsJsonAsync($"movies/{id}", movie);
    }
}
