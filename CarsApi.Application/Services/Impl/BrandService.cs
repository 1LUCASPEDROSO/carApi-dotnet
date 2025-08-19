using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Update;
using CarsApi.Domain.Entities;
using CarsApi.Application.Interfaces;
using CarsApi.Application;

namespace CarsApi.Domain.Services.Impl
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<BrandResponseDto> AddBrand(BrandCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
            {
                throw AppExceptions.InvalidField("name");
            }
            var brandResponse = await _brandRepository.GetBrandByName(dto.Name);
            if (brandResponse != null)
            {
                throw AppExceptions.Conflict(dto.Name);
            }
            var brand = new Brand { Name = dto.Name };
            var createdBrand = await _brandRepository.AddBrand(brand);
            return new BrandResponseDto(createdBrand.Id,createdBrand.Name);
        }

        public Task DeleteBrand(int Id)
        {
            return  _brandRepository.DeleteBrand(Id);
        }

        public async Task<List<BrandResponseDto>> GetAllBrands()
        {
           var brands = await _brandRepository.GetAllBrandsAsync();
           return brands.Select(b => new BrandResponseDto(b.Id,b.Name)).ToList();
        }

        public async Task<BrandResponseDto?> GetBrandById(int Id)
        {
            if (Id == 0)
            {
                throw AppExceptions.InvalidId("brand");
            }
            var brandResponse = await _brandRepository.GetBrandById(Id);
            if (brandResponse == null)
            {
                throw AppExceptions.NotFound("brand");  
            }
            return new BrandResponseDto(brandResponse.Id, brandResponse.Name);
        }

        public async Task<BrandResponseDto?> GetBrandByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw AppExceptions.InvalidField("name");
            }
            var brandResponse = await _brandRepository.GetBrandByName(name);
            return new BrandResponseDto(brandResponse.Id,brandResponse.Name);
        }

        public async Task<BrandUpdateDto> UpdateBrand(BrandUpdateDto updateDto)
        {
            if (updateDto.Id <= 0)
            {
                throw AppExceptions.InvalidId("brand");
            }
            else if (string.IsNullOrWhiteSpace(updateDto.Name)) {
                throw AppExceptions.InvalidField("name");
            }
            var updatedBrand = new Brand { Id = updateDto.Id, Name = updateDto.Name };
            var brand = await _brandRepository.UpdateBrand(updateDto.Id, updatedBrand);
            return new BrandUpdateDto(brand.Id,brand.Name);
        }
    }
}