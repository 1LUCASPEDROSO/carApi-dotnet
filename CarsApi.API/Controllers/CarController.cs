using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCars();
            return Ok(cars);
        }
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetCarById(id);
            return Ok(car);
        }
        [HttpPost]
        [Authorize(Roles = "admin,car-manager")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCar(CreateCarDto dto)
        {
            var car = await _carService.AddCar(dto);
            return Ok(car);
        }
        [HttpPut]
        [Authorize(Roles = "admin,car-manager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            var updateCar = await _carService.UpdateCar(dto);
            return Ok(updateCar);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,car-manager")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _carService.DeleteCar(id);
            return Ok();
        } 
    }
}