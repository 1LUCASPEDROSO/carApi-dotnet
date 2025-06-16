using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;

namespace CarsApi.Application.Services
{
    public interface ICarService
    {
         Task<List<ResponseCarDto>> GetAllCars();
        Task<ResponseCarDto> GetCarById(int Id);
        Task<ResponseCarDto> AddCar(CreateCarDto dto);
        Task<UpdateCarDto> UpdateCar(UpdateCarDto updateDto);
        Task DeleteCar(int Id);
    }
}