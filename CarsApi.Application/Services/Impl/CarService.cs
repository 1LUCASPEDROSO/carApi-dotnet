using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.Interfaces;
using CarsApi.Domain.Entities;
using CarsApi.Domain.Services;

namespace CarsApi.Application.Services.Impl
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IModelRepository _modelRepository;
        public CarService(ICarRepository carRepository, IModelRepository modelRepository)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
        }

        public async Task<ResponseCarDto> AddCar(CreateCarDto dto)
        {
            if (dto.Model_id <= 0)
            {
                throw new NotImplementedException("Model id is not 0");
            }
            if (!await VerifyModelExists(dto.Model_id))
            {
                throw new NotImplementedException("Model not exists");
            }
            var car = new Car { Timestamp_Cadaster = ToUnixTimestamp(dto.RegisterDate), Model_id = dto.Model_id, Year = dto.Year, Gas_type = dto.Gas_type, Num_doors = dto.Num_doors, Color = dto.Color };
            var createdCar = await _carRepository.AddCar(car);
            return new ResponseCarDto(
                createdCar.Id,
                FromUnixTimestamp(createdCar.Timestamp_Cadaster),
                createdCar.Model_id,
                createdCar.Year,
                createdCar.Gas_type,
                createdCar.Num_doors,
                createdCar.Color
                );
        }

        public async Task DeleteCar(int Id)
        {
            if (Id <= 0)
            {
                throw new NotImplementedException("Id < 0 not exists");
            }
            if (!await VerifyCarExitsById(Id))
            {
                throw new NotImplementedException("Id not exists");
            }
            await _carRepository.DeleteCar(Id);
            return;
        }

        public async Task<List<ResponseCarDto>> GetAllCars()
        {
            var cars = await _carRepository.GetAllCarsAsync();
            if (cars == null)
            {
                throw new NotImplementedException("Cars not exists");
            }
            return cars.Select(c => new ResponseCarDto(c.Id, FromUnixTimestamp(c.Timestamp_Cadaster), c.Model_id, c.Year, c.Gas_type, c.Num_doors, c.Color)).ToList();
        }

        public async Task<ResponseCarDto> GetCarById(int Id)
        {
            if (Id <= 0)
            {
                throw new NotImplementedException("Id < 0 not exists");
            }
            var Car = await _carRepository.GetCarById(Id);
            if (Car == null)
            { 
               throw new NotImplementedException("Car not exists"); 
            }
            return new ResponseCarDto(
                Car.Id,
                FromUnixTimestamp(Car.Timestamp_Cadaster),
                Car.Model_id,
                Car.Year,
                Car.Gas_type,
                Car.Num_doors,
                Car.Color
            );
        }

        public async Task<UpdateCarDto> UpdateCar(UpdateCarDto updateDto)
        {
            if (updateDto.Id <= 0)
            {
                throw new NotImplementedException("Id <0 not exists");
            }
            if (!await VerifyModelExists(updateDto.Model_id))
            {
                throw new NotImplementedException("Model not exists");
            }
            if (!await VerifyCarExitsById(updateDto.Id))
            { 
                throw new NotImplementedException("Car not exists");
            }
            var updateCar = new Car
            {
                Timestamp_Cadaster = ToUnixTimestamp(updateDto.RegisterDate),
                Model_id = updateDto.Model_id,
                Year = updateDto.Year,
                Gas_type = updateDto.Gas_type,
                Num_doors = updateDto.Num_doors,
                Color = updateDto.Color
            };
            var updatedCar = await _carRepository.UpdateCar(updateDto.Id, updateCar);
            return new UpdateCarDto(
                updatedCar.Id,
                FromUnixTimestamp(updateCar.Timestamp_Cadaster),
                updatedCar.Model_id,
                updatedCar.Year,
                updatedCar.Gas_type,
                updatedCar.Num_doors,
                updatedCar.Color
            );
        }

        private async Task<bool> VerifyModelExists(int model_id)
        {
            var model = await _modelRepository.GetModelById(model_id);
            return model != null;
           
        }
        private static DateTime FromUnixTimestamp(long timestamp)
        {
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).UtcDateTime;
        }

        private static long ToUnixTimestamp(DateTime date)
        {
            return new DateTimeOffset(date).ToUnixTimeSeconds();
        }
        private async Task<bool> VerifyCarExitsById(int Id)
        {
            var car = await _carRepository.GetCarById(Id);
            return car != null;
        }
    }
}