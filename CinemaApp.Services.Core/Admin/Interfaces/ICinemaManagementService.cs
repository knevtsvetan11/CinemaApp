using CinemaApp.Web.ViewModels.Admin.CinemaManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Admin.Interfaces;

public  interface ICinemaManagementService
{
    Task<IEnumerable<CinemaIndexViewModel>> GetAllCinemaManagementBoardDataAsync();

    Task<bool> AddCinemaAsync(CinemaManagementAddFormModel model);

    Task<EditCinemaFormModel> GetCinemaByIdAsync(string id);

    Task<bool> EditCinemaAsync(EditCinemaFormModel inputModel);
}
