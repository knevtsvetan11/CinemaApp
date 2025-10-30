
using CinemaApp.Services.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace CinemaApp.Web.Infrastructure.Middlewares;

public  class ManagerAccesRestrictionMiddleware
{
    private readonly RequestDelegate _next;

    public ManagerAccesRestrictionMiddleware(RequestDelegate next)
    {
        this._next = next;
       
    }

    public async Task InvokeAsync(HttpContext context, IManagerService managerService)
    {
       // Lector say it's not good practice to inject service here!!!

        string path = context.Request.Path.ToString().ToLower();

        if (path.StartsWith("/manager"))
        {
            var user = context.User;

            if(!(context.User.Identity?.IsAuthenticated ?? false))
            {
                context.Response.StatusCode = 403;
                return;
            }
            else
            {
                bool isAuthUserManager = await managerService.ExistByUserIdAsync(context.User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (!isAuthUserManager)
                {
                    context.Response.StatusCode = 403;
                    return;
                }
            }
        }

        await _next(context);
    }

    public void AppendManagerAuthCookie( HttpContext httpContext)
    {
        //CookieBuilder builder = new CookieBuilder()
        //{
        //    Name = httpContext.User.
        //};

    }
}
