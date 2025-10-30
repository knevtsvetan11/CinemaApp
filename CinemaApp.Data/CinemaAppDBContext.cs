namespace CinemaApp.Data;

using CinemaApp.Data.Configuration;
using CinemaApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
public class CinemaAppDBContext : IdentityDbContext<ApplicationUser>
{
    public CinemaAppDBContext(DbContextOptions<CinemaAppDBContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Movie> Movies { get; set; } = null!;

    public virtual DbSet<ApplicationUserMovie> ApplicationUserMovies { get; set; } = null!;

    public virtual DbSet<Cinema>  Cinemas  { get; set; } = null!;

    public virtual DbSet<CinemaMovie> CinemaMovies { get; set; } = null!;

    public virtual DbSet<Ticket> Tickets { get; set; } = null!;

    public virtual DbSet<Manager> Managers { get; set; } = null!;

    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MovieConfiguration());

        modelBuilder.ApplyConfiguration(new ApplicationUserMovieConfiguration());

        modelBuilder.ApplyConfiguration(new CinemaConfiguration());

        modelBuilder.ApplyConfiguration(new CinemaMovieConfiguration());

        modelBuilder.ApplyConfiguration(new TicketConfiguration());



    }

}
