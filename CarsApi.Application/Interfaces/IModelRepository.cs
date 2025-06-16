using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.Interfaces
{
    public interface IModelRepository
    {
        Task<List<Model>> GetAllModelsAsync();
        Task<Model?> GetModelById(int Id);
        Task<Model?> GetModelByName(String name);
        Task<Model> AddModel(Model model);
        Task<Model> UpdateModel(int Id, Model updateModel);
        Task DeleteModel(int Id);
    }
}