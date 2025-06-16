using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetAllCarsAsync();
        Task<Car?> GetCarById(int Id);
        Task<Car> AddCar(Car car);
        Task<Car> UpdateCar(int Id, Car carUpdate);
        Task DeleteCar(int Id);
    }
}