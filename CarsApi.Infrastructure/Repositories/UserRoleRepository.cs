using CarsApi.Application.Interfaces;
using CarsApi.Domain.Entities;
using CarsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRolesRepository
    {
        private readonly AppDbContext context;
        public UserRoleRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<UserRole>> AddRolesToUser(int userId, List<int> roleIds)
        {
            var userRolesToAdd = new List<UserRole>();

            foreach (int roleId in roleIds)
            {
                var userRole = new UserRole
                {
                    UserId = userId,
                    RoleId = roleId
                };

                userRolesToAdd.Add(userRole);
            }

            if (userRolesToAdd.Count != 0)
            {
                await context.UserRoles.AddRangeAsync(userRolesToAdd);
                await context.SaveChangesAsync();
            }

            return userRolesToAdd;
        }

        public async Task DeleteAllRolesFromUser(int userId)
        {
            var roles = await context.UserRoles.Where(u => u.UserId == userId).ToListAsync();
            context.UserRoles.RemoveRange(roles); 
            await context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetRolesByUserId(int userId)
        {
            return await context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Include(ur => ur.Role)
                .Select(ur => ur.Role)
                .ToListAsync();
        }

        public async Task RemoveRoleFromRoleId(int roleId)
        {
            var role = await context.UserRoles.FirstOrDefaultAsync(r => r.RoleId == roleId);
            if (role != null)
            {
                context.UserRoles.Remove(role);
            }
            await context.SaveChangesAsync();

        }

        public async Task RemoveRoleFromUser(int userId, int roleId)
        {
            var role = await context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
            if (role != null)
            {
                context.UserRoles.Remove(role);
            }
            await context.SaveChangesAsync();
        }

        public async Task<bool> UserHasRole(int userId, int roleId)
        {
            var role = await context.UserRoles.FirstOrDefaultAsync(x => x.UserId == userId && x.RoleId == roleId);
            if (role != null)
            {
                return true;
            }
            return false;
        }
    }
}