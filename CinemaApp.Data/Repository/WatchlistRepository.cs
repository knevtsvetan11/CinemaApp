using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Data.Repository;

public class WatchlistRepository : BaseRepository<ApplicationUserMovie, object>,IWatchlistRepository
{
    
    public WatchlistRepository(CinemaAppDBContext dBContext) : base(dBContext)
    {
    }

    public async Task<bool> Exists(string userId, string movieId)
    {
        return await this. _dbContext.Set<ApplicationUserMovie>()
                                .AnyAsync(am => am.UserId == userId && am.MovieId == movieId);
    }

    public async Task<ApplicationUserMovie?> GetCompositeKeyAsync(string userId, string movieId)
    {
        return await this._dbContext.Set<ApplicationUserMovie>()
                               .FirstOrDefaultAsync(am => am.UserId == userId && am.MovieId == movieId);
    }

}
