using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Data.Models;

public class Cinema
{

    public Guid Id { get; set; }  //Has Id – a Guid, Primary Key


    public string Name { get; set; } = null!;//Has Name – a string with min length 2 and max length 80 (required)


    public string Location { get; set; } = null!;//Has Location – string with min length 2 and max length 50 (required)


    public bool IsDeleted { get; set; }//Has IsDeleted – bool (default value == false)


    public ICollection<CinemaMovie> CinameMovies { get; set; } = new HashSet<CinemaMovie>();   //Has CinameMovies – a collection of type CinemaMovie

    public Guid? ManagerId { get; set; } 

    public virtual Manager? Manager { get; set; } 
}
