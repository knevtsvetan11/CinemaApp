using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Services.Core
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this._movieRepository = movieRepository;
        }

        public async Task AddMovieAsync(MovieFormInputViewModel inputModel)
        {
            Movie movie = new Movie()
            {
                Id = inputModel.Id,
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                Director = inputModel.Director,
                Description = inputModel.Description,
                Duration = inputModel.Duration,
                ReleaseDate = DateTime.ParseExact(inputModel.ReleaseDate, AppDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = inputModel.ImageUrl
            };

            await _movieRepository.AddAsync(movie);

        }

        public async Task<MovieEditViewModel> GetMovieEditModelAsync(string Id)
        {
            Movie movie = await this._movieRepository.GetByIdAsync(Guid.Parse(Id));
            if (movie == null)
                return null;

            MovieEditViewModel viewModel = new MovieEditViewModel()
            {
                Id = Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Director = movie.Director,
                Duration = movie.Duration,
                ReleaseDate = movie.ReleaseDate.ToString(),
                Description = movie.Description,
                ImageUrl = movie.ImageUrl
            };
            return viewModel;
        }

        public async Task<bool> EditModelAsync(MovieEditViewModel model)
        {
            try
            {
                Movie movie = await this._movieRepository.GetByIdAsync(Guid.Parse(model.Id));
                if (movie == null)
                    return false;


                movie.Title = model.Title;
                movie.Genre = model.Genre;
                movie.ReleaseDate = DateTime.Parse(model.ReleaseDate);
                movie.Director = model.Director;
                movie.Duration = model.Duration;
                movie.Description = model.Description;
                movie.ImageUrl = model.ImageUrl;
                await this._movieRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public async Task<IEnumerable<AllMoviesIndexViewModel>> GetAllMoviesAsync()
        {
            IEnumerable<AllMoviesIndexViewModel> allMovies = (await this._movieRepository.GetAllAsync())
                .Select(m => new AllMoviesIndexViewModel()
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(AppDateFormat),
                    Director = m.Director,
                    ImageUrl = m.ImageUrl
                });


            return allMovies;
        }

        public async Task<MovieDetailsViewModel> GetMovieDetailsByIdAsync(string Id)
        {

            Movie movie = await this._movieRepository.GetByIdAsync(Guid.Parse(Id));

            MovieDetailsViewModel movieDetails = new MovieDetailsViewModel()
            {
                Id = movie.Id.ToString(),
                Title = movie.Title,
                Genre = movie.Genre,
                ReleaseDate = movie.ReleaseDate.ToString(),
                Director = movie.Director,
                Duration = movie.Duration,
                Description = movie.Description,
                ImageUrl = movie.ImageUrl
            };
            return movieDetails;
        }

        public async Task<DeleteMovieViewModel> SoftDeleteConfirmModelAsync(string Id)
        {

            Movie movie = await this._movieRepository.GetByIdAsync(Guid.Parse(Id));
            if (movie == null)
                return null;
            DeleteMovieViewModel model = new DeleteMovieViewModel();
            model.Id = movie.Id;
            model.Title = movie.Title;
            model.ImageUrl = movie.ImageUrl;
            return model;

        }

        public async Task<bool> SoftDeleteAsync(string Id)
        {
            ///zadava se na IsDeleted = true; no ostava na stranicata !! tova e problem
            ///opravi i avtentikaciite ponje gost moje da trie i editva!
            try
            {
                Movie movie = await this._movieRepository.GetByIdAsync(Guid.Parse(Id));
                if (movie == null)
                    return false;

                movie.IsDeleted = true;
                await this._movieRepository.SaveChangesAsync();
               
            }
            catch (Exception)
            {

                return false;
            }
            return true;

        }
    }
}
