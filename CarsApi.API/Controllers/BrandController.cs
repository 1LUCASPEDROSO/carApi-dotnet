using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Update;
using CarsApi.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers{
    [ApiController]
    [Produces("application/json")]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllBrands()
        {
            var brands = await _brandService.GetAllBrands();
            return Ok(brands);
        }
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brands = await _brandService.GetBrandById(id);
            return Ok(brands);
        }
        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetBrandByName(string name)
        {
            var brands = await _brandService.GetBrandByName(name);
            return Ok(brands);
        }
        [Authorize(Roles = "admin,brand-manager")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBrand(BrandCreateDto dto)
        {
            var brands = await _brandService.AddBrand(dto);
            return Ok(brands);
        }
        [Authorize(Roles = "admin,brand-manager")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBrand(BrandUpdateDto dto)
        {
            var upddatedBrand = await _brandService.UpdateBrand(dto);
            return Ok(upddatedBrand);
        }
        [Authorize(Roles = "admin,brand-manager")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _brandService.DeleteBrand(id);
            return Ok();
        }
    }
}