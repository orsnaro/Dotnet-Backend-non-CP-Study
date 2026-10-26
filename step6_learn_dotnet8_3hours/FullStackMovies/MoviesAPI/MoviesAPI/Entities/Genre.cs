using System.ComponentModel.DataAnnotations;


namespace MoviesAPI.Entities{
    public class Genre {
        public int Id { get; set; }

        [Required]
        public required string Name {get; set;}

    }

}

