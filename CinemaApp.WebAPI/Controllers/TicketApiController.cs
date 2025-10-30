using CinemaApp.Services.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.ComponentModel.DataAnnotations;
using CinemaApp.WebAPI.DTO_s;


namespace CinemaApp.WebAPI.Controllers;

[Route("api/internal/[controller]")]
[ApiController]
[Authorize]
public class TicketApiController : ControllerBase
{
    private readonly ITicketService _ticketService;
    public TicketApiController(ITicketService ticketService)
    {
        this._ticketService = ticketService;
    }

    
    [HttpPost("Buy")]
  
    public async Task<ActionResult> Buy([FromBody] BuyRequestModel model)
    {

        ///do tuk si i tova e null !!! biskvitkata s blokirva i ne moje da se izvleche userid
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        bool isCorrectlyAdded = false;
        if (!String.IsNullOrWhiteSpace(model.movieId) && !String.IsNullOrWhiteSpace(model.cinemaId)
            && !String.IsNullOrWhiteSpace(model.showtime))
        {
            isCorrectlyAdded = await this._ticketService.AddTicketAsync(model.cinemaId, model. movieId, model. quantity, model. showtime, userId);
            if (!isCorrectlyAdded)
                return this.BadRequest();
        }
          
        return this.Ok();

    }
 
}
