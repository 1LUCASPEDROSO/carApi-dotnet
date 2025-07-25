using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Application.DTOs.Response
{
    public record ResponseAllUserDto(int Id,string Name, string Email)
    {
        
    }
}