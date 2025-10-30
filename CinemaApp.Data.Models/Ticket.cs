using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models;

public  class Ticket
{

    public Guid Id { get; set; }//Has Id – a unique Guid, Primary Key

    public decimal Price { get; set; } //Has Price – a decimal (required)

    public Guid? CinemaMovieId { get; set; }//Has CinemaId – a Guid, foreign key(required)

    public CinemaMovie? CinemaMovieProjection{ get; set; }

    public string UserId { get; set; }//Has UserId – a string, foreign key(required)

    public ApplicationUser User { get; set; } = null!;//Has User – IdentityUser(required)
}
