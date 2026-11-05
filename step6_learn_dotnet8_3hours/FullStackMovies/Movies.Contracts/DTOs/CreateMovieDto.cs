namespace Movies.Contracts.DTOs;


public record CreateMovieDto
{//(mutable)
        public required string Name { get; set; }

        public string? Director {get; set;}

        public decimal? Price { get; set; }

        public DateOnly? ReleaseDate { get; set; }

        //foreign key
    public int? GenreId { get; set; }
}
