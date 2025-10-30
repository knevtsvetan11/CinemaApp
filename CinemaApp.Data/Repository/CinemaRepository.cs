using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Repository;

public class CinemaRepository : BaseRepository<Cinema, Guid>,ICinemaRepository
{
    

    public CinemaRepository(CinemaAppDBContext dBContext) : base(dBContext)
    {
    }

    
}
