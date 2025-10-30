using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models;

public  class ApplicationUser : IdentityUser
{ 
  

    public  Manager? Manager { get; set; }

    public virtual ICollection<ApplicationUserMovie> WatchlistMovies { get; set; }
        = new HashSet<ApplicationUserMovie>();

    public virtual ICollection<Ticket> Tickets { get; set; }
       = new HashSet<Ticket>();

}
