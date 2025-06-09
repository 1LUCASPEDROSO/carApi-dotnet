using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Update;
using CarsApi.Domain.Entities;

namespace CarsApi.Domain.Services
{
    public interface IModelService
    {
        Task<List<ModelResponseDto>> GetAllModels();
        Task<ModelResponseDto?> GetModelById(int Id);
        Task<ModelResponseDto?> GetModelByName(String name);
        Task<ModelResponseDto> AddModel(ModelCreateDto dto);
        Task<ModelUpdateDto> UpdateModel(ModelUpdateDto updateDto);
        Task DeleteModel(int Id);
    }

    
}