using CinemaApp.Web.ViewModels.Watchlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Interfaces;

public  interface IWatchlistService
{
    Task<IEnumerable<WatchlistViewModel>> GetUserWatchlistAsync(string userId);
    Task<bool> AddToUserWatchlistAsync(string userId, string movieId);
    Task<bool> RemoveMovieToWatchlistAsync(string userId, string movieId);
}
