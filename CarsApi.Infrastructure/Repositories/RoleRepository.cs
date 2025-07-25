using CarsApi.Application.Interfaces;
using CarsApi.Domain.Entities;
using CarsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext context;
        public RoleRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Role> AddRole(Role role)
        {
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
            return role;
        }

        public async Task DeleteRole(int Id)
        {
            var role = await context.Roles.FindAsync(Id);
            if (role != null)
            {
                context.Roles.Remove(role);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleById(int Id)
        {
            return await context.Roles.FindAsync(Id);
        }

        public async Task<Role?> GetRoleByName(string Name)
        {
            return await context.Roles.FirstOrDefaultAsync(x => x.Name == Name);
        }

        public async Task<Role> UpdatRole(int Id, Role updateRole)
        {
            var role = await context.Roles.FindAsync(Id);
            context.Roles.Entry(role).CurrentValues.SetValues(updateRole);
            await context.SaveChangesAsync();
            return await context.Roles.FindAsync(Id);
        }
    }
}