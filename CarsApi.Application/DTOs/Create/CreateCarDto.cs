using CarsApi.Domain.Enums;

namespace CarsApi.Application.DTOs.Create
{
    public record CreateCarDto(DateTime RegisterDate, int Model_id, int Year, Fuel_type Gas_type,int Num_doors, string Color);
}
