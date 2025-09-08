using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core;

public class WatchlistService : IWatchlistService
{
    private readonly IWatchlistRepository _watchlistRepository;

    public WatchlistService(IWatchlistRepository watchlistRepository)
    {
        this._watchlistRepository = watchlistRepository;
    }

    public async Task<bool> AddToUserWatchlistAsync(string userId, string movieId)
    {

        if (!Guid.TryParse(movieId, out var movieGuid)) return false;

        bool exists = await _watchlistRepository
            .GetAllAttached()
            .AnyAsync(u => u.ApplicationUserId == userId && u.MovieId == movieGuid);

        if (exists)
        {
            return false;
        }

        ApplicationUserMovie userMovie = new ApplicationUserMovie
        {
            ApplicationUserId = userId,
            MovieId = movieGuid
        };
        await _watchlistRepository.AddAsync(userMovie);

        return true;
    }

    public async Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId)
    {
        return await _watchlistRepository.GetAllAttached()
            .Where(um => um.ApplicationUserId == userId)
            .Select(um => new WatchlistViewModel
            {
                MovieId = um.Movie.Id.ToString(),
                Title = um.Movie.Title,
                Genre = um.Movie.Genre,
                ImageUrl = um.Movie.ImageUrl,
                ReleaseDate = um.Movie.ReleaseDate.ToString(),
            }).ToListAsync();
    }

    public async Task<bool> RemoveMovieToWatchlistAsync(string userId, string movieId)
    {

        if (!Guid.TryParse(movieId, out var movieGuid))
            return false;

        var exist = await _watchlistRepository.GetAllAttached()
            .FirstOrDefaultAsync(x => x.ApplicationUserId == userId && x.MovieId == movieGuid);

        if (exist == null)
            return false;

        _watchlistRepository.Delete(exist);
        return true;
    }


}
