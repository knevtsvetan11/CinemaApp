using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Configuration;

public class CinemaMovieConfiguration : IEntityTypeConfiguration<CinemaMovie>
{
    public void Configure(EntityTypeBuilder<CinemaMovie> entity)
    {
        entity
            .HasKey(c => c.Id);

        entity
            .HasOne(c => c.Movie)
            .WithMany()
            .IsRequired()
            .HasForeignKey(c => c.MovieId);


        entity
         .HasOne(c => c.Cinema)
         .WithMany()
         .IsRequired()
         .HasForeignKey(c => c.CinemaId);

        entity
           .Property(c => c.AvailableTickets)
           .HasDefaultValue(0)
           .IsRequired();

        entity
            .HasQueryFilter(c => c.IsDeleted == false);

        entity
            .Property(c => c.IsDeleted)
            .HasDefaultValue(false);

        entity
           .Property(c => c.Showtime)
           .IsRequired()
           .HasMaxLength(5);


        entity
            .HasOne(c => c.Movie)
            .WithMany(c => c.MovieProjections)
            .HasForeignKey(c => c.MovieId);

        entity
            .HasOne(c => c.Cinema)
            .WithMany(c => c.CinameMovies)
            .HasForeignKey(c => c.CinemaId);

        entity.HasData(ProjectSeeds());
    }

    private IEnumerable<CinemaMovie> ProjectSeeds()
    {
        return new CinemaMovie[]
        {
            new CinemaMovie
            {
                Id = Guid.Parse("36c4aff9-5768-42b6-a428-4a8d70e2fae5"),
                MovieId = Guid.Parse("ae50a5ab-9642-466f-b528-3cc61071bb4c"),
                CinemaId = Guid.Parse("30c8c49e-647d-4a5c-ba64-012263bd0ae5"),//Harry potter
                AvailableTickets = 150,
                IsDeleted = false,
                Showtime = "18:00"
            },
            new CinemaMovie
            {
                Id = Guid.Parse("f0ae490c-a577-49f2-9952-197b5fba0ffb"),
                MovieId = Guid.Parse("777634e2-3bb6-4748-8e91-7a10b70c78ac"),//Lord of the rings
                CinemaId = Guid.Parse("30c8c49e-647d-4a5c-ba64-012263bd0ae5"),
                AvailableTickets = 120,
                IsDeleted = false,
                Showtime = "21:00"
            },
            new CinemaMovie
            {
                Id = Guid.Parse("7d38ab07-7c5d-450b-9375-e85d42a41da4"),
                MovieId = Guid.Parse("68fb84b9-ef2a-402f-b4fc-595006f5c275"),//Inception
                CinemaId = Guid.Parse("30c8c49e-647d-4a5c-ba64-012263bd0ae5"),
                AvailableTickets = 180,
                IsDeleted = false,
                Showtime = "19:30"
            },
            new CinemaMovie
            {
                Id = Guid.Parse("609296a6-d936-46db-9584-148370d0a8f5"),
                MovieId = Guid.Parse("02b52bb0-1c2b-49a4-ba66-6d33f81d38d1"), //The Dark Knight
                CinemaId = Guid.Parse("30c8c49e-647d-4a5c-ba64-012263bd0ae5"),
                AvailableTickets = 90,
                IsDeleted = false,
                Showtime = "16:45"
            }
        };
    }
}
