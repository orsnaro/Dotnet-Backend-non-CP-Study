using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MoviesAPI.Entities{
    public class Movie{
        //primary key (implicitly) unique - not null - required
        public required int Id { get; set; }

        [Required]
        [StringLength(120)]
        public required string Name { get; set; }

        [Required]
        // [Range(1, 1000)] //this is more of a buisness rule, not a validation rule (not right layer)
        public decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }





        //foreign key
        public int GenreId { get; set; }


        //navigation property
        [ValidateNever]
        public Genre? Genre { get; set; }

    }
}

