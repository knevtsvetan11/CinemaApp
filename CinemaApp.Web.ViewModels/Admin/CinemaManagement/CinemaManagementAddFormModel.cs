using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels.Admin.CinemaManagement;

public  class CinemaManagementAddFormModel
{
    [Required(ErrorMessage = "Name is required!")]
    [MinLength(4,ErrorMessage = "Name's length must be min: 4 sumbols.")]
    [MaxLength(20, ErrorMessage = "Name's length must be max: 20 sumbols.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Location is required!")]
    [MinLength(4, ErrorMessage = "Location's length must be min: 4 sumbols.")]
    [MaxLength(20, ErrorMessage = "Location's length must be max: 20 sumbols.")]
    public string Location { get; set; } = null!;
}
