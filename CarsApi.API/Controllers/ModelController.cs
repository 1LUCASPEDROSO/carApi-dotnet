using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Update;
using CarsApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers
{
    [ApiController]
    [Route("api/models")]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModels()
        {
            var models = await _modelService.GetAllModels();
            return Ok(models);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetModelById(int id)
        {
            var model = await _modelService.GetModelById(id);
            return Ok(model);
        }
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetModelByName(String name)
        {
            var model = await _modelService.GetModelByName(name);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(ModelCreateDto dto)
        {
            var model = await _modelService.AddModel(dto);
            return Ok(model);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateModel(ModelUpdateDto dto)
        {
            var updatedModel = await _modelService.UpdateModel(dto);
            return Ok(updatedModel);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int Id)
        {
            await _modelService.DeleteModel(Id);
            return Ok();
        } 
    }
}