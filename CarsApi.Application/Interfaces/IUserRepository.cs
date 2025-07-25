using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserByLogin(string email, string password);
        Task<User?> GetUserById(int Id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int Id, User updateUser);
        Task DeleteUser(int Id);
    }
}