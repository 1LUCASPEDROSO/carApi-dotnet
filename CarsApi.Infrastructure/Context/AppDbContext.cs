using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarsApi.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }   
        public DbSet<Brand> Brands => Set<Brand>();
        
    }
}