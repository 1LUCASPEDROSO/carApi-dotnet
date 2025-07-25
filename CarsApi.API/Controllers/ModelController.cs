using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Update;
using CarsApi.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers
{
    [ApiController]
    [Route("api/models")]
    [Produces("application/json")]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllModels()
        {
            var models = await _modelService.GetAllModels();
            return Ok(models);
        }
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetModelById(int id)
        {
            var model = await _modelService.GetModelById(id);
            return Ok(model);
        }
        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetModelByName(string name)
        {
            var model = await _modelService.GetModelByName(name);
            return Ok(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin,model-manager")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddModel(ModelCreateDto dto)
        {
            var model = await _modelService.AddModel(dto);
            return Ok(model);
        }
        [HttpPut]
        [Authorize(Roles = "admin,model-manager")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateModel(ModelUpdateDto dto)
        {
            var updatedModel = await _modelService.UpdateModel(dto);
            return Ok(updatedModel);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,model-manager")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteModel(int id)
        {
            await _modelService.DeleteModel(id);
            return Ok();
        }
    }
}