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
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext context;
        public BrandRepository(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<Brand> AddBrand(Brand brand)
        {
            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
            return brand;
        }

        public async Task DeleteBrand(int Id)
        {
            var brand = await context.Brands.FindAsync(Id);
            if (brand != null)
            {
                context.Brands.Remove(brand);
                await context.SaveChangesAsync();
             }
        }

        public Task<List<Brand>> GetAllBrandsAsync()
        {
            return context.Brands.ToListAsync();
        }

        public async Task<Brand?> GetBrandById(int Id)
        {
           return await context.Brands.FindAsync(Id);
        }

        public async Task<Brand?> GetBrandByName(String name)
        {
           return await context.Brands.FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<Brand> UpdateBrand(int Id, Brand updatedBrand)
        {
            var brand = await context.Brands.FindAsync(Id);
            context.Brands.Entry(brand).CurrentValues.SetValues(updatedBrand);
            await context.SaveChangesAsync();
            return brand; 
        }
    }
}