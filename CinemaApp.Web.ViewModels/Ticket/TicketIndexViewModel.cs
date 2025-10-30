﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Ticket;

public  class TicketIndexViewModel
{
    public string MovieImageUrl { get; set; } = null!;

    public string MovieTitle { get; set; } = null!;

    public string CinemaName { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string ShowTime { get; set; } = null!;

    public int TicketCount { get; set; } 
}
