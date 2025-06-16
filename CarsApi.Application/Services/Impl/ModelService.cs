using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs;
using CarsApi.Domain.Entities;
using CarsApi.Application.Interfaces;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Update;

namespace CarsApi.Domain.Services.Impl
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _Modelrepository;
        private readonly IBrandRepository _brandRepository;

        public ModelService(IModelRepository modelRepository, IBrandRepository brandRepository)
        {
            _Modelrepository = modelRepository;
            _brandRepository = brandRepository;
        }

        public async Task<ModelResponseDto> AddModel(ModelCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name)|| dto.Fipe_value <= 0.00 || dto.Brand_id <= 0)
            {
                throw new ArgumentNullException(nameof(dto.Name));
            }
            var brand = await _brandRepository.GetBrandById(dto.Brand_id);
            if (brand == null)
            { 
                throw new ArgumentNullException("Marca inexistente");
            }
            var model = new Model { Name = dto.Name, Fipe_value = dto.Fipe_value, Brand_id = dto.Brand_id };
            var createdModel = await _Modelrepository.AddModel(model);
            return new ModelResponseDto(createdModel.Id,createdModel.Brand_id,createdModel.Name,createdModel.Fipe_value);
        }

        public  Task DeleteModel(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentNullException("Id menor que 0 não aceito");
            }
            var model =  _brandRepository.GetBrandById(Id);
            if (model == null)
            {
                throw new ArgumentNullException("modelo inexistente");
            }
            return _Modelrepository.DeleteModel(Id);
        }

        public async Task<List<ModelResponseDto>> GetAllModels()
        {
            var models = await _Modelrepository.GetAllModelsAsync();
            return models.Select(m => new ModelResponseDto(m.Id,m.Brand_id,m.Name,m.Fipe_value)).ToList();
        }

        public async Task<ModelResponseDto?> GetModelById(int Id)
        {
            if (Id >= 0)
            {
                throw new ArgumentException("Id inexistente");
             }
            var model = await _Modelrepository.GetModelById(Id);
            if (model != null) {
                return new ModelResponseDto(model.Id,model.Brand_id, model.Name, model.Fipe_value);
            }
            return null;
        }

        public async Task<ModelResponseDto?> GetModelByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Nome invalido");
            }
            var model = await _Modelrepository.GetModelByName(name);
            return new ModelResponseDto(model.Id,model.Brand_id,model.Name, model.Fipe_value);
            
        }

        public async Task<ModelUpdateDto> UpdateModel(ModelUpdateDto updateDto)
        {
            if (updateDto.Id <= 0 || string.IsNullOrWhiteSpace(updateDto.Name))
            {
                throw new Exception("Ids menores que zero ou nome null nao aceito ");
            }
            var brand = await _brandRepository.GetBrandById(updateDto.Brand_id);
            if (brand == null)
            { 
                throw new ArgumentNullException("Marca inexistente");
            }
            var updatedModel = new Model { Brand_id = updateDto.Brand_id,Name = updateDto.Name, Fipe_value = updateDto.Fipe_value };
            var model = await _Modelrepository.UpdateModel(updateDto.Id, updatedModel);
            return new ModelUpdateDto(model.Id,model.Fipe_value,model.Name,model.Brand_id);
        }
    }
}