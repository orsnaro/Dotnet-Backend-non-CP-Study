namespace Movies.Contracts.DTOs;

public record MovieDto(
    string Name,
    decimal? Price,
    string? GenreName,
    string? Director,
    DateOnly? ReleaseDate
);