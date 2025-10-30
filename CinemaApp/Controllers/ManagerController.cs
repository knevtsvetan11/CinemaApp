using CinemaApp.Services.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

public class ManagerController : BaseController
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        this._managerService = managerService;
    }

    public IActionResult Index()
    {
        return this.Ok("I'm manager!");
    }
}
