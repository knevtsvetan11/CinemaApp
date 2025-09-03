using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Movie;

public  class MovieEditViewModel
{
    public string Id { get; set; } = null!;

    [Required]
    [StringLength(50,MinimumLength =2 ,ErrorMessage ="Title length must be in range [2..50].")]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Genre  length must be in range [2..20].")]
    public string Genre { get; set; } = null!;

    [Required]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Director name's length must be in range [2..30].")]
    public string Director { get; set; } = null!;

    [Required]
    [Range(1, 300, ErrorMessage = "Duration must be between 1 and 300 minutes.")]
    public int Duration { get; set; } 

    public string ReleaseDate { get; set; } = null!;

    [Required]
    [StringLength(200, MinimumLength = 20, ErrorMessage = "Description  length must be in range [20..200].")]
    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }
}
