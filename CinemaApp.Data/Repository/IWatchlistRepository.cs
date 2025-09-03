using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Models;

namespace CinemaApp.Data.Repository;

public  interface IWatchlistRepository : IRepository<ApplicationUserMovie,object>  
{
    Task<ApplicationUserMovie?> GetCompositeKeyAsync(string userId,string movieId);

    Task<bool> Exists (string userId,string movieId);
}
