using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();
        Task<Role?> GetRoleById(int Id);
        Task<Role?> GetRoleByName(String Name);
        Task<Role> AddRole(Role role);
        Task<Role> UpdatRole(int Id, Role updateRole);
        Task DeleteRole(int Id);
    }
}