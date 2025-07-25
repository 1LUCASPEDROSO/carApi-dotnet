using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Update;
using CarsApi.Application.Interfaces;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.Services.Impl
{
    public class RoleService(IRoleRepository roleRepository, IUserRolesRepository userRolesRepository) : IRoleService
    {
        private readonly IRoleRepository roleRepository = roleRepository;
        private readonly IUserRolesRepository userRolesRepository = userRolesRepository;

        public async Task<ResponseRoleDto> AddRole(CreateRoleDto createRoleDto)
        {
            var role = new Role { Name = createRoleDto.Name };
            var createdRoles = await roleRepository.AddRole(role);
            return new ResponseRoleDto(
                createdRoles.Id,
                createdRoles.Name
            );
        }

        public async Task<List<ResponseRoleDto>> GetAllRoles()
        {
            var roles = await roleRepository.GetAllRoles();
            var dtoList = new List<ResponseRoleDto>();
            foreach (var role in roles)
            {
                dtoList.Add(new ResponseRoleDto(role.Id, role.Name));
            }
            return dtoList;
        }

        public async Task<ResponseRoleDto> GetRoleById(int Id)
        {
            var role = await roleRepository.GetRoleById(Id);
            return new ResponseRoleDto(role.Id, role.Name);
        }

        public async Task RemoveRole(int Id)
        {
            var role = await roleRepository.GetRoleById(Id);
            if (role == null)
            {
                AppExceptions.NotFound("Role");
            }
            await userRolesRepository.RemoveRoleFromRoleId(Id);
            await roleRepository.DeleteRole(Id);
        }

        public async Task<ResponseRoleDto> UpdateRole(UpdateRoleDto updateRoleDto)
        {
            var role = await roleRepository.GetRoleById(updateRoleDto.Id);
            if (role == null)
            {
                AppExceptions.NotFound("Role");
            }
            var updateRole = new Role
            {
                Id = updateRoleDto.Id,
                Name = updateRoleDto.Name,
            };
           var updatedRole = await roleRepository.UpdatRole(updateRoleDto.Id, updateRole);
            return new ResponseRoleDto(
                updatedRole.Id,
                updatedRole.Name
            ) ;
        }

    }
}