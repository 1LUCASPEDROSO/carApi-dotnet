using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;


namespace CarsApi.Domain.Repositories
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllBrandsAsync();
        Task<Brand?> GetBrandById(int Id);
        Task<Brand?> GetBrandByName(String name);
        Task<Brand> AddBrand(Brand brand);
        Task<Brand> UpdateBrand(int Id, Brand updatedBrand);
        Task DeleteBrand(int Id);
    }
}