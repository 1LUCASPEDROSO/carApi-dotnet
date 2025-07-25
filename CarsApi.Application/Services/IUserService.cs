using CarsApi.Application.DTOs.Create;
using CarsApi.Application.DTOs.Response;
using CarsApi.Application.DTOs.Update;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.Services
{
    public interface IUserService
    {
        Task<List<ResponseAllUserDto>> GetAllUsers();
        Task<ResponseUserDto?> GetUserById(int Id);
        Task<ResponseUserDto> AddUser(CreateUserDto dto);
        Task<ResponseAllUserDto> UpdateUser(UpdateUserDto updateDto);
        Task DeleteUser(int Id);
        Task<List<UserRole>> GetRolesById(int Id);
    }
}