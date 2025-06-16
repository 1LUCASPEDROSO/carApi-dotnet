using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Application.DTOs.Create
{
    public record ResponseCarDto(int Id,DateTime RegisterDate, int Model_id, int Year, string Gas_type,int Num_doors, string Color);

}
