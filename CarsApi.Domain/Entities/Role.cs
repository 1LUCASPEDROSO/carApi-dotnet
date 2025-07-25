using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<UserRole>? UserRoles { get; set; }
}
    
}