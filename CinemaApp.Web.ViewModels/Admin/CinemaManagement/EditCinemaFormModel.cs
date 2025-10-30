using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CinemaApp.GCommon.ApplicationConstants.CinemaConstants;
using static CinemaApp.GCommon.ApplicationConstants.ValidationMessages;



namespace CinemaApp.Web.ViewModels.Admin.CinemaManagement;

public  class EditCinemaFormModel
{
    //[Required]
    public string Id { get; set; } = null;

    //[Required(ErrorMessage = RequiredError)]
    //[MinLength(NameMinLength,ErrorMessage = MinLengthError)]
    //[MaxLength(NameMaxLength,ErrorMessage = MaxLengthError)]
    public string Name { get; set; } = null!;

    //[Required(ErrorMessage = RequiredError)]
    //[MinLength(NameMinLength, ErrorMessage = MinLengthError)]
    //[MaxLength(NameMaxLength, ErrorMessage = MaxLengthError)]
    public string Location { get; set; } = null!;
}
