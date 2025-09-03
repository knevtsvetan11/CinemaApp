using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CinemaApp.Data.Repository;

public  interface IMovieRepository : IRepository<Movie, Guid>
{

}
