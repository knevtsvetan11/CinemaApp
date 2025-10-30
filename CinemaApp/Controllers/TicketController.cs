using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaApp.Web.Controllers;

public class TicketController : BaseController
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        this._ticketService = ticketService;
    }

  
    [HttpGet]
    public async Task<IActionResult> Index()
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


        if (string.IsNullOrWhiteSpace(userId))
            return NotFound();

        IEnumerable<TicketIndexViewModel> tickets = await this._ticketService.GetTicketsUserAsync(userId);

        if (tickets == null)
            return NotFound();

        return View(tickets);
    }
}
