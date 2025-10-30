namespace CinemaApp.Web.Controllers;

using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreGeneratedDocument;
using CinemaApp.Data.Models;
using CinemaApp.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<ApplicationUser> _userManager;
    public HomeController(ILogger<HomeController> logger,UserManager<ApplicationUser>userManager)
    { 
        this._logger = logger;
        this._userManager = userManager;
    }
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        if (User.IsInRole("Admin"))
        {
            return this.RedirectToAction("Index", "Home", new { area = "Admin" });

        }
        return View();
    }

  

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet("/Home/Error/{statusCode}")]
    public IActionResult Error(int? statusCode)
    {
        if (statusCode == null)
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        else if (statusCode == 401 || statusCode == 403)
            return View("UnAuthurizadeError");
        if (statusCode == 404)
            return View("NotFoundError");



        return View();
    }
}
