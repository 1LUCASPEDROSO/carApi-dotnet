using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Update;
using CarsApi.Application.Interfaces;
using CarsApi.Domain.Entities;
using Microsoft.VisualBasic;

namespace CarsApi.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserRolesRepository userRoleRepository;


        public UserService(IUserRepository userRepository, IUserRolesRepository userRoleRepository)
        {
            this.userRepository = userRepository;
            this.userRoleRepository = userRoleRepository;
        }
        public async Task<ResponseUserDto> AddUser(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };
            var CreatedUser = await userRepository.AddUser(user);
            var userRoles = await userRoleRepository.AddRolesToUser(CreatedUser.Id, dto.RolesIds);
            var dtoListRole = userRoles.Select(ur => new ResponseRoleDto(
                ur.RoleId,
                ""
                )).ToList();
            return new ResponseUserDto
            (
                CreatedUser.Id,
                CreatedUser.Name,
                CreatedUser.Email,
                dtoListRole
            );
        }

        public async Task DeleteUser(int Id)
        {
            var user = await userRepository.GetUserById(Id);
            if (user == null)
            {
                AppExceptions.NotFound("User");
            }
            await userRoleRepository.DeleteAllRolesFromUser(Id);
            await userRepository.DeleteUser(Id);
        }

        public async Task<List<ResponseAllUserDto>> GetAllUsers()
        {
            var users = await userRepository.GetAllUsers();
            var dtoList = new List<ResponseAllUserDto>();
            foreach (var user in users)
            {
                dtoList.Add(new ResponseAllUserDto(
                  user.Id,
                  user.Name,
                  user.Email
                ));
            }
            return dtoList;
        }

        public async Task<ResponseUserDto?> GetUserById(int Id)
        {
            if (Id <= 0)
            {
                AppExceptions.InvalidId("user");
            }
            var user = await userRepository.GetUserById(Id);
            var roles = await userRoleRepository.GetRolesByUserId(Id);
            var dtoListRole = roles.Select(ur => new ResponseRoleDto(
                ur.Id,
                ur.Name
                )).ToList();
            return new ResponseUserDto(
                user.Id,
                user.Name,
                user.Email,
                dtoListRole
            );
        }

        public async Task<ResponseAllUserDto> UpdateUser(UpdateUserDto updateDto)
        {
            var user = await userRepository.GetUserById(updateDto.Id);
            if (user == null)
            {
                AppExceptions.NotFound("user");
            }
            var updatedUser = new User
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
                Email = updateDto.Email,
                Password = updateDto.Password
            };
            await userRepository.UpdateUser(updateDto.Id, updatedUser);
            return new ResponseAllUserDto(
                updatedUser.Id,
                updatedUser.Name,
                updatedUser.Email
            );
        }
        public async Task<List<UserRole>> GetRolesById(int Id)
        {
            var roles = await userRoleRepository.GetRolesByUserId(Id); // retorna List<Role>

            var userRoles = roles.Select(role => new UserRole
            {
                UserId = Id,
                RoleId = role.Id,
                Role = role
            }).ToList();

            return userRoles;
        }


    }
}