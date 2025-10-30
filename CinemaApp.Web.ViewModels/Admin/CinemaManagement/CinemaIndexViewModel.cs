using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Admin.CinemaManagement;

public class CinemaIndexViewModel
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public bool IsDeleted { get; set; } 

}
