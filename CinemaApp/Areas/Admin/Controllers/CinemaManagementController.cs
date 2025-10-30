using CinemaApp.Services.Core.Admin.Interfaces;
using CinemaApp.Web.ViewModels.Admin.CinemaManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using  static CinemaApp.GCommon.ApplicationConstants.TempDataKeys;

namespace CinemaApp.Web.Areas.Admin.Controllers;

public class CinemaManagementController : BaseAdminController
{
    private readonly ICinemaManagementService _cinemaManagementService;

    public CinemaManagementController(ICinemaManagementService cinemaManagementService)
    {
        this._cinemaManagementService = cinemaManagementService;
         
    }

    [HttpGet]
    public async Task<IActionResult> Manage()
    {
         IEnumerable<CinemaIndexViewModel> cinemasIndexViewModels = await this._cinemaManagementService
            .GetAllCinemaManagementBoardDataAsync();
    
        return View(cinemasIndexViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CinemaManagementAddFormModel model)
    {
        //TO DO: Add TempData[] monitoring global in CinemaWebApp! Very functional!
        bool isCinemaExist = await this._cinemaManagementService.AddCinemaAsync(model);
        if(!isCinemaExist)
        {
            TempData[ErrorMessage] = "Failed to add cinema. A cinema with this name or location might already exist, or there was a database error.";
            return Redirect("Manage");
        }

        TempData[SuccessMessage] = "Successfully added new Cinema!"; 
        return RedirectToAction("Manage");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        if (String.IsNullOrWhiteSpace(id))
        {
            TempData[ErrorMessage] = "Failed to show cinema to edit because 'Id' is null or whitespace.";
            return RedirectToAction("Manage");
        }

        EditCinemaFormModel model = await this._cinemaManagementService
            .GetCinemaByIdAsync(id);
        if(model == null)
        {
            TempData[ErrorMessage] = "Selected Cinema does not exsist.";
            return  RedirectToAction("Manage");
        }

        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditCinemaFormModel inputModel)
    {
        bool isEditSuccesly = false;
        if(ModelState.IsValid)
        {
            isEditSuccesly  =  await this._cinemaManagementService.EditCinemaAsync(inputModel);
        }
        if(!isEditSuccesly)
        {
            TempData[ErrorMessage] = "Failed to edit Cinema.";
           return RedirectToAction("Edit");
        }

        TempData[SuccessMessage] = "Cinema is correctly edited.";
        return RedirectToAction("Manage");
    }

    [HttpPost]
    public async Task<IActionResult> ToggleDelete(string id) ///SoftDelete
    {
        if (String.IsNullOrWhiteSpace(id))
        {
            TempData[ErrorMessage] = "Failed to remove Cinema: 'Id' is null or whitespace.";
            return RedirectToAction("Manage");
        }

        bool isDeleteSuccesly = await this._cinemaManagementService.SoftDelete(id);
        if (!isDeleteSuccesly)
        {
            TempData[ErrorMessage] = "Failed to delete Cinema.";
            return RedirectToAction("Manage");

        }

        TempData[SuccessMessage] = "Cinema is succesly deleted.";
        return RedirectToAction("Manage");
    }
}
