using CarsApi.Domain.Entities;
using CarsApi.Application.Interfaces;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Update;
using CarsApi.Application;

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
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw AppExceptions.InvalidField("name");

            if (dto.Fipe_value <= 0)
                throw AppExceptions.InvalidField("fipe_value");

            if (dto.Brand_id <= 0)
                throw AppExceptions.InvalidId("model");

            var brand = await _brandRepository.GetBrandById(dto.Brand_id);
            if (brand == null)
            {
                throw AppExceptions.NotFound("model");
            }
            var model = new Model { Name = dto.Name, Fipe_value = dto.Fipe_value, Brand_id = dto.Brand_id };
            var createdModel = await _Modelrepository.AddModel(model);
            return new ModelResponseDto(createdModel.Id, createdModel.Brand_id, createdModel.Name, createdModel.Fipe_value);
        }

        public async Task DeleteModel(int Id)
        {
            if (Id <= 0)
            {
                throw AppExceptions.InvalidId("model");
            }
            var model = await _Modelrepository.GetModelById(Id);
            if (model == null)
            {
                throw AppExceptions.NotFound("model");
            }
            await _Modelrepository.DeleteModel(Id);
        }

        public async Task<List<ModelResponseDto>> GetAllModels()
        {
            var models = await _Modelrepository.GetAllModelsAsync();
            return models.Select(m => new ModelResponseDto(m.Id, m.Brand_id, m.Name, m.Fipe_value)).ToList();
        }

        public async Task<ModelResponseDto?> GetModelById(int Id)
        {
            if (Id <= 0)
            {
                throw AppExceptions.InvalidId("model");
            }
            var model = await _Modelrepository.GetModelById(Id);
            if (model == null)
            {
                throw AppExceptions.NotFound("model");
            }
            return new ModelResponseDto(model.Id, model.Brand_id, model.Name, model.Fipe_value); 
        }

        public async Task<ModelResponseDto?> GetModelByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw AppExceptions.InvalidField("name");
            }
            var model = await _Modelrepository.GetModelByName(name);
            if (model == null)
            {
                return null;
            }
            return new ModelResponseDto(model.Id, model.Brand_id, model.Name, model.Fipe_value);

        }

        public async Task<ModelUpdateDto> UpdateModel(ModelUpdateDto updateDto)
        {
            if (updateDto.Id <= 0 || string.IsNullOrWhiteSpace(updateDto.Name))
            {
                throw new ArgumentNullException("Ids menores que zero ou nome null nao aceito ");
            }
            var brand = await _brandRepository.GetBrandById(updateDto.Brand_id);
            if (brand == null)
            {
                throw AppExceptions.NotFound("model");
            }
            var updatedModel = new Model { Id = updateDto.Id, Brand_id = updateDto.Brand_id, Name = updateDto.Name, Fipe_value = updateDto.Fipe_value };
            var model = await _Modelrepository.UpdateModel(updateDto.Id, updatedModel);
            return new ModelUpdateDto(model.Id, model.Fipe_value, model.Name, model.Brand_id);
        }
    }
}