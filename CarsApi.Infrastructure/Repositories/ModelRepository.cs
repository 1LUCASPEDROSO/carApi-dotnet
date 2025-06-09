using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;
using CarsApi.Application.Interfaces;
using CarsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Infrastructure
{
    public class ModelRepository : IModelRepository
    {
        private readonly AppDbContext context;
        public ModelRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Model> AddModel(Model model)
        {
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteModel(int Id)
        {
            var model = await context.Models.FindAsync(Id);
            if (model != null)
            {
                context.Models.Remove(model);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Model>> GetAllModelsAsync()
        {
            return await context.Models.ToListAsync();
        }

        public async Task<Model?> GetModelById(int Id)
        {
            return await context.Models.FindAsync(Id);
        }

        public async Task<Model?> GetModelByName(string name)
        {
            var model = await context.Models.FirstOrDefaultAsync(m => m.Name == name);
            return model;
        }

        public async Task<Model> UpdateModel(int Id, Model updateModel)
        {
            var model = await context.Models.FindAsync(Id);
                context.Models.Entry(model).CurrentValues.SetValues(updateModel);
                await context.SaveChangesAsync();
                return model;
            }
        
    }
}