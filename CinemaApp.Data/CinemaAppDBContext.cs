namespace CinemaApp.Data;

using CinemaApp.Data.Configuration;
using CinemaApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
public class CinemaAppDBContext : IdentityDbContext
{
    public CinemaAppDBContext(DbContextOptions<CinemaAppDBContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Movie> Movies { get; set; } = null!;

    public virtual DbSet<ApplicationUserMovie> ApplicationUserMovies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MovieConfiguration());

      modelBuilder.ApplyConfiguration(new ApplicationUserMovieConfiguration());
    }

}
