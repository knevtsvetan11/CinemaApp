using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace CinemaApp.Services.Core;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly ICinemaMovieRepository _cinemaMovieRepository;

    public TicketService(ITicketRepository ticketRepository, ICinemaMovieRepository cinemaMovieRepository)
    {
        this._ticketRepository = ticketRepository;
        this._cinemaMovieRepository = cinemaMovieRepository;
    }

    public async Task<IEnumerable<TicketIndexViewModel>> GetTicketsUserAsync(string userId)
    {

        ///do tuk si no razledai zashto raboti taka tozi action!
        IEnumerable<TicketIndexViewModel> existTicket = new List<TicketIndexViewModel>();
        existTicket = await this._ticketRepository
            .GetAllAttached()
            .Where(x => x.UserId.ToString().ToLower() == userId.ToLower())
            .Select(x => new TicketIndexViewModel()
            {
                MovieTitle = x.CinemaMovieProjection.Movie.Title,
                MovieImageUrl = x.CinemaMovieProjection.Movie.ImageUrl,
                CinemaName = x.CinemaMovieProjection.Cinema.Name,
                Price = x.Price.ToString(),
                ShowTime = x.CinemaMovieProjection.Showtime,
                TicketCount = x.CinemaMovieProjection.Tickets.Count,

            }).ToListAsync();


        ///Ne vryshta nishto ? ? problem
        return existTicket;

    }


    public async Task<bool> AddTicketAsync(string cinemaId, string movieId, int quantity, string showtime, string userId)
    {


        CinemaMovie? projection = await this._cinemaMovieRepository
            .GetAllAttached()
            .FirstAsync(cm => cm.CinemaId.ToString().ToLower() == cinemaId.ToLower() &&
            cm.MovieId.ToString().ToLower() == movieId.ToLower() && cm.Showtime.ToLower() == showtime.ToLower());

       
        if (projection != null )
        {

            Ticket ticket = new Ticket()
            {

                Price = new Random().Next(5, 10),// sluchaina cena
                CinemaMovieProjection = projection, // Замени с реално ID
                UserId = userId// Замени с реално ID
            };
            await this._ticketRepository.AddAsync(ticket);
            return true;
        }

        return false;


    }
}
