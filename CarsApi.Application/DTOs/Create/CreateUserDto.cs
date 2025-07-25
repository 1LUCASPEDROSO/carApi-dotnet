using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Application.DTOs.Create
{
    public record CreateUserDto(string Name, string Email, string Password, List<int>RolesIds)
    {
        
    }
}