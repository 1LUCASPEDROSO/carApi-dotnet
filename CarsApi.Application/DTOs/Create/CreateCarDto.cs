using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsApi.Application.DTOs.Create
{
    public record CreateCarDto(int Id,long Timestamp_Cadaster, int Model_id, int Year, string Gas_type,int Num_doors, string Color);

}
