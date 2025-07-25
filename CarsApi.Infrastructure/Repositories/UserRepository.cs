using CarsApi.Application.Interfaces;
using CarsApi.Domain.Entities;
using CarsApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext context;
        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<User> AddUser(User user)
        {   
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;  
        }

        public async Task DeleteUser(int Id)
        {
            var user = await context.Users.FindAsync(Id);
            if (user != null)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUserByLogin(string email,string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;
        }

        public async Task<User?> GetUserById(int Id)
        {
            return await context.Users.FindAsync(Id);
        }

        public async Task<User> UpdateUser(int Id, User updateUser)
        {
            var user = await context.Users.FindAsync(Id);
            context.Users.Entry(user).CurrentValues.SetValues(updateUser);
            await context.SaveChangesAsync();
            var updatedUser = await context.Users.FindAsync(Id);
            return updatedUser;
        }

    }
}