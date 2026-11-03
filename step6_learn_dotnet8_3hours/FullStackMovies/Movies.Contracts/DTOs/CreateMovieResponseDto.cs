namespace Movies.Contracts.DTOs;

public record CreateMovieResponseDto(
    int Id,
    string Title,
    int? GenreId
);