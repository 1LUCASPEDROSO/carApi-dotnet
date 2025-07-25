using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.SecurityDto;

namespace CarsApi.Application.Services
{
    public interface IAuthService
    {
         Task<ResponseAuthDto?> GetUserByLogin(RequestAuthDto dto);
    }
}