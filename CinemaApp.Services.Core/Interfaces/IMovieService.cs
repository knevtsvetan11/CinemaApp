using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Web.ViewModels.Movie;
namespace CinemaApp.Services.Core.Interfaces;

public interface IMovieService
{

    Task<MovieDetailsViewModel> GetMovieDetailsByIdAsync(string Id);
    Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync();
    Task AddMovieAsync(MovieFormInputViewModel inputModel);
    Task <MovieEditViewModel> GetMovieEditModelAsync(string Id);
    Task<bool> EditModelAsync(MovieEditViewModel model);
    Task<DeleteMovieViewModel> SoftDeleteConfirmModelAsync(string Id);

    Task<bool> SoftDeleteAsync(string Id);


}
