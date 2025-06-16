using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Application.DTOs.Response
{
    public record ModelResponseDto(int Id,int Brand_id, string Name,float Fipe_value);  
}