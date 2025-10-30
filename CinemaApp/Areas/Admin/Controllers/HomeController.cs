using CinemaApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Areas.Admin.Controllers;

public class HomeController : BaseAdminController
{

    public HomeController()
    {
        
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
