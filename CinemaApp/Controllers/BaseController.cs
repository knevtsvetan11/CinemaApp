using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaApp.Web.Controllers;

[Authorize]
public abstract  class BaseController : Controller
{
   
}
