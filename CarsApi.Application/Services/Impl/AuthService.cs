using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.SecurityDto;
using CarsApi.Application.Interfaces;

namespace CarsApi.Application.Services.Impl
{
    public class AuthService : IAuthService
    {
         private readonly IUserRepository userRepository;
        private readonly IUserRolesRepository userRoleRepository;


        public AuthService(IUserRepository userRepository, IUserRolesRepository userRoleRepository)
        {
            this.userRepository = userRepository;
            this.userRoleRepository = userRoleRepository;
        }

        public async Task<ResponseAuthDto?> GetUserByLogin(RequestAuthDto dto)
        {
            var user = await userRepository.GetUserByLogin(dto.Email, dto.Passowrd);
            if (user == null)
            {
                AppExceptions.NotFound("user");
            }
            var roles = await userRoleRepository.GetRolesByUserId(user.Id);
            var dtoListRole = roles.Select(ur => new ResponseRoleDto(
               ur.Id,
               ur.Name
               )).ToList();
            return new ResponseAuthDto(
                user.Id,
                user.Name,
                user.Email,
                dtoListRole
            ); 
        }
    }
}