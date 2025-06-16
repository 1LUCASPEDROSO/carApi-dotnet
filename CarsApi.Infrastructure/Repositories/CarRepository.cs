using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;
using CarsApi.Application.Interfaces;
using CarsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CarsApi.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext context;
        public CarRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Car> AddCar(Car car)
        {
            await context.Cars.AddAsync(car);
            await context.SaveChangesAsync();
            return car;
        }

        public async Task DeleteCar(int Id)
        {
            var car = await context.Cars.FindAsync(Id);
            context.Cars.Remove(car);
            await context.SaveChangesAsync();
        }

        public Task<List<Car>> GetAllCarsAsync()
        {
           return context.Cars.ToListAsync();
        }

        public async Task<Car?> GetCarById(int Id)
        {
            return await context.Cars.FindAsync(Id);
        }

        public async Task<Car> UpdateCar(int Id, Car carUpdate)
        {
            var car = await context.Cars.FindAsync(Id);
            context.Cars.Entry(car).CurrentValues.SetValues(carUpdate);
            return car;
        }
    }
}