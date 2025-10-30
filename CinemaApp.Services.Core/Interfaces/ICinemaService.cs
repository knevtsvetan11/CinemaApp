﻿using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Interfaces;

public  interface ICinemaService
{
    Task<IEnumerable<UsersCinemaIndexViewModel>> GetAllCinemasAsync();

    Task<CinemaProgramViewModel?> GetProgramByIdAsync(string cinemaId);

}
