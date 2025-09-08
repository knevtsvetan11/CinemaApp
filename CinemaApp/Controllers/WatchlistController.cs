using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Watchlist;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaApp.Web.Controllers
{
    public class WatchlistController : BaseController
    {
        public readonly IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            this._watchlistService = watchlistService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IEnumerable<WatchlistViewModel> userWatchlists = await this._watchlistService.GetUserWatchlistAsync(userId);
            return View(userWatchlists);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string movieId)
         {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (String.IsNullOrWhiteSpace(movieId) || userId == null)
                return BadRequest("Missing user or movie id.");

            bool iSuccesAdded = await this._watchlistService.AddToUserWatchlistAsync(userId, movieId);
            if (!iSuccesAdded)
                return Conflict("Already in watchlist or invalid movie id.");

            return Redirect(nameof(Index));
        }

        [HttpPost]
        public async  Task<IActionResult> Remove(string movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(movieId))
                return BadRequest("Missing user or movie id.");

             bool isRemovedFromWatchlist = await this._watchlistService
                .RemoveMovieToWatchlistAsync(userId,movieId);
            if(!isRemovedFromWatchlist)
                return Conflict("Not exist in watchlist or invalid movie id.");

            return Redirect(nameof(Index));

        }


    }
}
