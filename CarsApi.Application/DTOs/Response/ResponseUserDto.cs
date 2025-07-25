using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Domain.Entities;

namespace CarsApi.Application.DTOs.Response
{
    public record ResponseUserDto(int Id,string Name, string Email, List<ResponseRoleDto>Roles)
    {
        
    }
}