using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Models
{
    public  class Movie
    {
        [Comment("Movie Identifier")]
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Movie Title")]
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(EntityConstants.Movie.TitleMaxLength,ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = null!;

        [Comment("Movie Genre")]
        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(EntityConstants.Movie.GenreMaxLength, ErrorMessage = "Genre cannot exceed 50 characters.")]
        public string Genre { get; set; } = null!;

        [Comment("Movie Release Date")]
        [Required(ErrorMessage = "Release date is required.")]
        public DateTime  ReleaseDate { get; set; }

        [Comment("Movie Director")]
        [Required(ErrorMessage = "Director is required.")]
        [StringLength(EntityConstants.Movie.DirectorNameMaxLength, ErrorMessage = "Director cannot exceed 100 characters.")]

        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; } = false;


    }
}
