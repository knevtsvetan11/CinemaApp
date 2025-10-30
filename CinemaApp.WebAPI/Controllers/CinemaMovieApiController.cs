using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.Controllers;
using CinemaApp.Web.ViewModels.Cinema;
using CinemaApp.Web.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CinemaApp.Data.Common.EntityConstants;

namespace CinemaApp.WebAPI.Controllers;

[Route("api/[controller]")]
public class CinemaMovieApiController : ControllerBase
{
    private readonly IProjectionService _projectionService;
         

    public CinemaMovieApiController(IProjectionService projectionService)
    {
         this._projectionService = projectionService;
    }

    [HttpGet]
    [Route("Showtimes")]
    public async Task<ActionResult<IEnumerable<string>>> GetProjectionShowtimes(string cinemaId,string movieId)
    {
        IEnumerable<string> showtimes = await
            this._projectionService.GetProjectionShowtimeAsync(cinemaId, movieId);

        return  this.Ok( showtimes); 
    }

    [HttpGet]
    [Route("AvailableTickets")]
    public async Task<ActionResult<int>> GetAvailableTickets(string cinemaId,  string movieId, string showtime)
    {
        int availableTickets = await this._projectionService.GetAvailableTicketsCountAsync(cinemaId,movieId,showtime);
        return this.Ok(availableTickets);
    }

}
