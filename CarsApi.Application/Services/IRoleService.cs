using System.Data;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Update;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.Services
{
    public interface IRoleService
    {
        public Task<ResponseRoleDto> AddRole(CreateRoleDto createRoleDto);
        public Task<ResponseRoleDto> UpdateRole(UpdateRoleDto updateRoleDto);
        public Task<List<ResponseRoleDto>> GetAllRoles();
        public Task<ResponseRoleDto> GetRoleById(int Id);  
        public Task RemoveRole(int Id);
    }
}