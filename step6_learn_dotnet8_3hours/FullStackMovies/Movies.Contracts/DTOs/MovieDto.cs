using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.DTOs;


// //note: if defined as possitional records only! they by default will be : `{get; init;}` so you cant change values once created!
// public record MovieDto(//positional style (immutable)
//     string Name ,
//     decimal? Price,
//     string? GenreName,
//     string? Director,
//     DateOnly? ReleaseDate
// );

public record MovieDto
{//(mutable)

    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = "";

    [Range(0.001, double.MaxValue)]
    public decimal? Price { get; set; }

    public string? GenreName { get; set; }

    [Required]
    public int? GenreId {get; set;}
    public string? Director {get; set;}
    public DateOnly? ReleaseDate {get; set;}
}
