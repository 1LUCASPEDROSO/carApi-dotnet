using CarsApi.Application.DTOs.SecurityDto;
using CarsApi.Application.security;
using CarsApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly  TokenService tokenService;
        public AuthController(IAuthService authService1, TokenService tokenService1)
        {
            authService = authService1;
            tokenService = tokenService1;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login(RequestAuthDto dto)
        {
            var user = await authService.GetUserByLogin(dto);
            if (user == null)
            {
                throw new Exception("usuario nao encontrado");
            }
            var filtredUser = new ResponseAuthDto(
                user.Id,
                user.Name,
                user.Email,
                user.Roles
            );
            var token = tokenService.Generate(filtredUser);
            return Ok(new { token });
        }
    }
}