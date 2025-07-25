using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Application.DTOs.Update
{
    public record UpdateUserDto(int Id,string Name, string Email, string Password)
    {
        
    }
}