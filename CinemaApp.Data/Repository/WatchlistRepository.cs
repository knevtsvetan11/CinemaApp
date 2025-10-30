using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Repository;

public class WatchlistRepository : BaseRepository<ApplicationUserMovie, object>,IWatchlistRepository
{
    
    public WatchlistRepository(CinemaAppDBContext dBContext) : base(dBContext)
    {
    }

    public async Task<bool> Exists(string userId, string movieId)
    {
        return await this._dbContext.Set<ApplicationUserMovie>()
                                .AnyAsync(am => am.ApplicationUserId.ToString().ToLower() == userId && am.MovieId == Guid.Parse(movieId));
    }

    public async Task<ApplicationUserMovie?> GetCompositeKeyAsync(string userId, string movieId)
    {
        return await this._dbContext.Set<ApplicationUserMovie>()
                               .FirstOrDefaultAsync(am => am.ApplicationUserId.ToString().ToLower()  == userId && am.MovieId == Guid.Parse(movieId));
    }

    
}
