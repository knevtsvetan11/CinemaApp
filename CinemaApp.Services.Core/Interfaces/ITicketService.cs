using CinemaApp.Web.ViewModels.Ticket;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Interfaces;

public  interface ITicketService
{
    

    Task<IEnumerable<TicketIndexViewModel>> GetTicketsUserAsync(string userId);

    Task<bool> AddTicketAsync(string cinemaId, string movieId,int quantity, string showtime,string userId);

}
