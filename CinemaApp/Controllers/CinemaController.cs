using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Cinema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaApp.Web.Controllers;

public class CinemaController : BaseController
{
    private readonly ICinemaService _cinemaService;

    public CinemaController(ICinemaService cinemaService)
    {
        this._cinemaService = cinemaService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {

        IEnumerable<UsersCinemaIndexViewModel> models = new List<UsersCinemaIndexViewModel>();
           models =  await this._cinemaService.GetAllCinemasAsync();
        return View(models);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Program(string Id)
    {
        if (String.IsNullOrWhiteSpace(Id))
            return NotFound("Invalid 'Id' try again.");
        CinemaProgramViewModel? cinemaModel = await this._cinemaService
            .GetProgramByIdAsync(Id);
        if (cinemaModel == null)
            return NotFound();
        return View(cinemaModel);

    }


    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Details(string Id)
    {
        //// NE RABOTI IMA PROBLEM MOJE BI  V JS FAILA
        return View();

    }
}
