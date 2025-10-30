using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models;

public  class ApplicationUserMovie
{

    public string ApplicationUserId { get; set; } = null!;

    public virtual ApplicationUser ApplicationUser { get; set; } = null!;

    public Guid MovieId { get; set; }

    public virtual  Movie Movie { get; set; } = null!;
}
