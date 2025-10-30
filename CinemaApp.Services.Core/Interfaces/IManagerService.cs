using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Interfaces;

public  interface IManagerService
{
    Task<bool>  ExistByIdAsync(string Id);
    Task<bool> ExistByUserIdAsync(string Id);

}
