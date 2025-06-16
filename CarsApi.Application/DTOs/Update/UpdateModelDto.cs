using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Application.DTOs.Update
{
    public record ModelUpdateDto(int Id,float Fipe_value,string Name,int Brand_id);
    
}