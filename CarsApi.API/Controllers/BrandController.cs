using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs;
using CarsApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrands();
            return Ok(brands);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brands = await _brandService.GetBrandById(id);
            return Ok(brands);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetBrandByName(String name)
        {
            var brands = await _brandService.GetBrandByName(name);
            return Ok(brands);
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandCreateDto dto)
        {
            var brands = await _brandService.AddBrand(dto);
            return Ok(brands);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(BrandUpdateDto dto)
        {
            var upddatedBrand = await _brandService.UpdateBrand(dto);
            return Ok(upddatedBrand);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int Id)
        {
            await _brandService.DeleteBrand(Id);
            return Ok();
        }
    }
}