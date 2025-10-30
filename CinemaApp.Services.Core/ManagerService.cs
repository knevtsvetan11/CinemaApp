using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core;

public  class ManagerService : IManagerService
{
    private readonly IManagerRepository _managerRepository;

    public ManagerService(IManagerRepository managerRepository)
    {
          this._managerRepository = managerRepository;  
    }

    public async Task<bool> ExistByIdAsync(string Id)
    {
        bool result = false;
        if (!String.IsNullOrWhiteSpace(Id))
        {
           result =  await this._managerRepository
                .GetAllAttached()
                .AnyAsync(m => m.Id == Guid.Parse(Id));
        }
        return result;
    }

    public async Task<bool> ExistByUserIdAsync(string userId)
    {

        bool result = false;
        if (!String.IsNullOrWhiteSpace(userId))
        {
            result = await this._managerRepository
                 .GetAllAttached()
                 .AnyAsync(m => m.UserId.ToString().ToLower() == userId.ToLower());
        }
        return result;
    }

    /// SOME METHODS ....
}
