using CinemaApp.Data.Models;
using CinemaApp.Data.Repository;
using CinemaApp.Data.Repository.Interfaces;
using CinemaApp.Services.Core.Admin.Interfaces;
using CinemaApp.Web.ViewModels.Admin.CinemaManagement;
using CinemaApp.Web.ViewModels.Movie;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Services.Core.Admin;

public class CinemaManagementService : ICinemaManagementService
{
    private readonly ICinemaRepository _cinemaRepository;

    public CinemaManagementService(ICinemaRepository cinemaRepository)
    {
        this._cinemaRepository = cinemaRepository;
        //It's a good idea to inject Ilogger and project monitoring!! 
    }



    public async Task<IEnumerable<CinemaIndexViewModel>> GetAllCinemaManagementBoardDataAsync()
    {
        IEnumerable<CinemaIndexViewModel> existCinemas = (await this._cinemaRepository
            .GetAllAsync())
            .Select(c => new CinemaIndexViewModel()
            {
                Id = c.Id.ToString(),
                Name = c.Name,
                Location = c.Location,
                IsDeleted = c.IsDeleted,
            }).ToList();

        return existCinemas;
    }

    public async Task<bool> AddCinemaAsync(CinemaManagementAddFormModel model)
    {
        Cinema cinemaExist = await this._cinemaRepository
           .FirstOrDefaultAsync(c => c.Name.ToLower() == model.Name.ToLower() &&
           c.Location.ToLower() == model.Location.ToLower());

        if (cinemaExist == null)
        {
            cinemaExist = new Cinema
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Location = model.Location,
            };

            await this._cinemaRepository.AddAsync(cinemaExist);
            return true;
        }

        return false;
    }

    public async Task<EditCinemaFormModel> GetCinemaByIdAsync(string id)
    {
        EditCinemaFormModel cinemaFormModel = null;

        Cinema cinemaExist = await this._cinemaRepository
            .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == id.ToLower());
        
        if (cinemaExist != null)
        {
            cinemaFormModel = new EditCinemaFormModel
            {
                Id = cinemaExist.Id.ToString(),
                Name = cinemaExist.Name,
                Location = cinemaExist.Location,
            };
            return cinemaFormModel;
        }

        return cinemaFormModel;


    }

    public async Task<bool> EditCinemaAsync(EditCinemaFormModel inputModel)
    {

        Cinema cinema = await this._cinemaRepository
           .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() == inputModel.Id.ToLower());


        Cinema cinemaExist = await this._cinemaRepository
         .FirstOrDefaultAsync(c => c.Id.ToString().ToLower() != inputModel.Id.ToLower() && c.Name.ToLower() == inputModel.Name.ToLower()
         && c.Location.ToLower() == inputModel.Location.ToLower());

        if (cinemaExist != null)
            return false;

        if (cinema != null)
        {
            try
            {
                cinema.Name = inputModel.Name;
                cinema.Location = inputModel.Location;

                await this._cinemaRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        return false;
    }


}
