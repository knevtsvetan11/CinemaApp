using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{

    public void Configure(EntityTypeBuilder<Ticket> entity)
    {
        entity
           .HasKey(t => t.Id);


        entity
            .Property(t => t.Price)
             .HasPrecision(18, 2)
            .IsRequired();

        entity
            .HasOne(c => c.CinemaMovieProjection)
            .WithMany(c => c.Tickets)
            .HasForeignKey(c => c.CinemaMovieId);
          

        entity
            .Property(t => t.UserId)
            .IsRequired();

        entity
            .HasOne(t => t.User)
            .WithMany(t =>t.Tickets)
            .HasForeignKey(t => t.UserId)
            .IsRequired(true);

       // entity.HasData(SeedTickets());

    }

    //private List<Ticket> SeedTickets()
    //{
    //    //return new List<Ticket>()
    //    //{
    //    //     new Ticket
    //    //{
    //    // Id = Guid.Parse("7431298a-6aa3-4c54-bf2d-0470f2f3c1fb"),
    //    // Price = 15.00m,
    //    // CinemaMovieId = Guid.Parse("609296A6-D936-46DB-9584-148370D0A8F5"), // Замени с реално ID
    //    // UserId =Guid.Parse( "7a574241-4ae7-47a7-a7c6-bfe0169bcc41") // Замени с реално ID
    //    //}

    //    //};
    //}
}
