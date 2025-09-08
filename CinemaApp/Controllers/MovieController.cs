using CinemaApp.Data;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Interfaces;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Diagnostics;
using static CinemaApp.Web.ViewModels.ValidationMessagges;


namespace CinemaApp.Web.Controllers;

public class MovieController : BaseController
{
    private readonly IMovieService _movieService;
    public MovieController(IMovieService movieService)
    {
        this._movieService = movieService;
    }


    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string Id)
    {
        if (String.IsNullOrWhiteSpace(Id))
            return NotFound("Error mesagess: 'Id' can't be empty or null");
        bool isDeleted = await this._movieService.SoftDeleteAsync(Id);
        if (!isDeleted)
            return BadRequest("Something with deleting is gone wrong.Repeat try.");

        return RedirectToAction("Index");

    }


    [HttpGet]
    public async Task<IActionResult> Delete(string Id)
    {
        if (String.IsNullOrWhiteSpace(Id))
            return NotFound("Error mesagess: 'Id' can't be empty or null");
        DeleteMovieViewModel model = await this._movieService.SoftDeleteConfirmModelAsync(Id);
        if (model == null)
            return NotFound("Can't deleted movie because not exist.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(MovieEditViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        bool editSuccesly = await this._movieService.EditModelAsync(model);
        if (!editSuccesly)
            return BadRequest("Exception was throw when try to save new editing Movie");

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string Id)
    {
        if (String.IsNullOrWhiteSpace(Id))
            return BadRequest("'Id' can't be null or whitespase.");

        MovieEditViewModel model = await this._movieService.GetMovieEditModelAsync(Id);
        if (model == null)
            return NotFound();

        return View(model);
    }



    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Details(string Id)
    {


        MovieDetailsViewModel movie = await this._movieService.GetMovieDetailsByIdAsync(Id);
        return View(movie);
    }

    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        IEnumerable<AllMoviesIndexViewModel> allMovies = await this._movieService
            .GetAllMoviesAsync();

        return View(allMovies);
    }


    [HttpGet]
    public async Task<IActionResult> Add()
    {
        return this.View();
    }


    [HttpPost]
    public async Task<IActionResult> Add(MovieFormInputViewModel inputModel)
    {
        if (!this.ModelState.IsValid)
        {
            return this.View(inputModel);
        }

        await _movieService.AddMovieAsync(inputModel);
        return this.RedirectToAction(nameof(Index));


    }



}
