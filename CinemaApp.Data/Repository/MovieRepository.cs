using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;

namespace CinemaApp.Data.Repository;

public class MovieRepository : BaseRepository<Movie, Guid>,IMovieRepository
{
    public MovieRepository(CinemaAppDBContext dBContext) : base(dBContext)
    {
    }
}
