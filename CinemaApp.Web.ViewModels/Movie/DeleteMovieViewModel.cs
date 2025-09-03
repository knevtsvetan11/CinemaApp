using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Movie;

public  class DeleteMovieViewModel
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string ImageUrl { get; set; }
}
