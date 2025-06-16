using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs;
using CarsApi.Domain.Entities;

namespace CarsApi.Domain.Services
{
    public interface IBrandService
    {
        Task<List<BrandResponseDto>> GetAllBrands();
        Task<BrandResponseDto?> GetBrandById(int Id);
        Task<BrandResponseDto?> GetBrandByName(String name);
        Task<BrandResponseDto> AddBrand(BrandCreateDto dto);
        Task<BrandUpdateDto> UpdateBrand(BrandUpdateDto updateDto);
        Task DeleteBrand(int Id);
    }
}