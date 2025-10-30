using CinemaApp.Data.Configuration;
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

public class ProjectionService : IProjectionService
{
    private readonly ICinemaMovieRepository _cinemaMovieRepository;

    public ProjectionService(ICinemaMovieRepository cinemaMovieRepository)
    {
        this._cinemaMovieRepository = cinemaMovieRepository;
    }

    public async Task<IEnumerable<string>> GetProjectionShowtimeAsync(string cinemaId, string movieId)
    {
        IEnumerable<string> showtimes = new List<string>();

        if (!String.IsNullOrWhiteSpace(cinemaId) && !String.IsNullOrWhiteSpace(movieId))
        {
            showtimes = await this._cinemaMovieRepository
                           .GetAllAttached()
                           .Where(cm => cm.CinemaId.ToString().ToLower() == cinemaId.ToString().ToLower() &&
                           cm.MovieId.ToString().ToLower() == movieId.ToString().ToLower())
                           .Select(s => s.Showtime)
                           .ToListAsync();
        }


        return showtimes;
    }

    public async Task<int> GetAvailableTicketsCountAsync(string cinemaId, string movieId,string showtime)
    {
        CinemaMovie cinemaMovie = new CinemaMovie();
        cinemaMovie = await this._cinemaMovieRepository
        .GetAllAttached()
        .FirstOrDefaultAsync(cm => cm.CinemaId.ToString().ToLower() == cinemaId.ToLower() &&
        cm.MovieId.ToString().ToLower() == movieId.ToLower()
        && cm.Showtime.ToString().ToLower() == showtime.ToLower());
        
            return cinemaMovie.AvailableTickets;
            


    }
}
