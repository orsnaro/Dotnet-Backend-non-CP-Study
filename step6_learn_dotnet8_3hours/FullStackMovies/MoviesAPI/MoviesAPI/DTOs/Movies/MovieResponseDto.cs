namespace MoviesAPI.DTOs.Movies;

public record MovieResponseDto(
    int Id,
    string Title,
    int GenreId
);