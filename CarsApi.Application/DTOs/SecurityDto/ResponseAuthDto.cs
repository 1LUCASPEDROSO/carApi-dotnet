using CarsApi.Application.DTOs.Response;

namespace CarsApi.Application.DTOs.SecurityDto
{
    public record ResponseAuthDto (int Id,string Name, string Email, List<ResponseRoleDto>Roles)
    {
        
    }
}