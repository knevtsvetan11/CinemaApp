using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core;

public class CinemaService : ICinemaService
{
    private readonly ICinemaRepository _cinemaRepository;

    public CinemaService(ICinemaRepository cinemaRepository)
    {
        this._cinemaRepository = cinemaRepository;
    }


    public async Task<IEnumerable<UsersCinemaIndexViewModel>> GetAllCinemasAsync()
    {
        IEnumerable<UsersCinemaIndexViewModel> cinemas = new List<UsersCinemaIndexViewModel>();
        cinemas = (await this._cinemaRepository
           .GetAllAsync()).Select(c => new UsersCinemaIndexViewModel()
           {
               Id = c.Id.ToString(),
               Name = c.Name,
               Location = c.Location
           }).ToList();

        return cinemas;
    }

    public async Task<CinemaProgramViewModel?> GetProgramByIdAsync(string cinemaId)
    {
        // Expect the code carefly !

        Cinema? cinema = await this._cinemaRepository
         .GetAllAttached()
         .Include(c => c.CinameMovies)
         .ThenInclude(cm => cm.Movie)
         .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == cinemaId.ToLower());

        if (cinema == null)
            return null;

        CinemaProgramViewModel cinemaProgramViewModel = new CinemaProgramViewModel()
        {
            CinemaId = cinemaId,
            CinemaName = cinema.Name,
            CinemaData = $"{cinema.Name} Cinema city - {cinema.Location}",
            Movies = cinema.CinameMovies
            .Select(m => m.Movie)
            .Select(m => new CinemaProgramMovieViewModel()
            {
                Id = m.Id.ToString(),
                Title = m.Title,
                Director = m.Director,
                ImageUrl = m.ImageUrl
            }).ToArray()


        };

        return cinemaProgramViewModel;
        //ne e dovurshen koda tuk!
    }


}
