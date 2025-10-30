using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models;

public class CinemaMovie
{
    public Guid Id { get; set; } 


    public Guid MovieId { get; set; } // MovieId – a Guid, foreign key(required)


    public virtual Movie Movie { get; set; }  // Has Movie – Movie(required)

    
    public Guid CinemaId { get; set; }  // a Guid, foreign key(required)


    public  virtual Cinema Cinema { get; set; } = null!;  //Cinema – Cinema(required)


    public int AvailableTickets { get; set; }    // an int (required)


    public bool IsDeleted { get; set; }  // a bool (default: false)

    public string Showtime { get; set; } = null!;

    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();   //Has Tickets – a collection of type Ticket

}
