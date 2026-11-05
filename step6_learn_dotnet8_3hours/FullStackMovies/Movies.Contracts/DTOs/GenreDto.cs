namespace Movies.Contracts.DTOs;

// public record GenreDto// positional style (immutable)
// (
//     string Name
// );

public record GenreDto // mutable style
{
    public int Id {get; set;} = -1;
    public string Name {get; set;} = "";
}