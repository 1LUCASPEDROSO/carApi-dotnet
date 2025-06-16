using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
         [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carService.GetAllCars();
            return Ok(cars);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carService.GetCarById(id);
            return Ok(car);
        }
        [HttpPost]
        public async Task<IActionResult> AddCar(CreateCarDto dto)
        {
            var car = await _carService.AddCar(dto);
            return Ok(car);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarDto dto)
        {
            var updateCar = await _carService.UpdateCar(dto);
            return Ok(updateCar);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int Id)
        {
            await _carService.DeleteCar(Id);
            return Ok();
        } 
    }
}