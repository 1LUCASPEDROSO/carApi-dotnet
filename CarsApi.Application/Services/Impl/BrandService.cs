using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs;
using CarsApi.Domain.Entities;
using CarsApi.Domain.Repositories;

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
                throw new ArgumentNullException(nameof(dto.Name));
            }
            var brand = new Brand { Name = dto.Name };
            var createdBrand = await _brandRepository.AddBrand(brand);
            return new BrandResponseDto(createdBrand.Name);
        }

        public Task DeleteBrand(int Id)
        {
            return _brandRepository.DeleteBrand(Id);
        }

        public async Task<List<BrandResponseDto>> GetAllBrands()
        {
           var brands = await _brandRepository.GetAllBrandsAsync();
             return brands.Select(b => new BrandResponseDto(b.Name)).ToList();
        }

        public async Task<BrandResponseDto?> GetBrandById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Somente Ids maiores que 0 aceitos");
            }
            var brandResponse = await _brandRepository.GetBrandById(Id);
            return new BrandResponseDto(brandResponse.Name);
        }

        public async Task<BrandResponseDto?> GetBrandByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception($"{nameof(name)} must not be empty.");
            }
            var brandResponse = await _brandRepository.GetBrandByName(name);
            return new BrandResponseDto(brandResponse.Name);
        }

        public async Task<BrandUpdateDto> UpdateBrand(BrandUpdateDto updateDto)
        {
            if (updateDto.Id <= 0 || string.IsNullOrWhiteSpace(updateDto.Name))
            {
                throw new Exception("Ids menores que zero ou nome null nao aceito ");
            }
            var updatedBrand = new Brand { Name = updateDto.Name };
            var brand = await _brandRepository.UpdateBrand(updateDto.Id, updatedBrand);
            return new BrandUpdateDto(brand.Id,brand.Name);
        }
    }
}