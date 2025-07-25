using CarsApi.Domain.Entities;

namespace CarsApi.Application.Interfaces
{
    public interface IUserRolesRepository
    {
        Task<List<Role>> GetRolesByUserId(int userId);
        Task<List<UserRole>> AddRolesToUser(int userId, List<int> rolesIds);
        Task RemoveRoleFromUser(int userId, int roleId);
        Task RemoveRoleFromRoleId(int roleId);
        Task DeleteAllRolesFromUser(int userId);
        Task<bool> UserHasRole(int userId, int roleId);

    }
}