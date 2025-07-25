using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CarsApi.Application.DTOs.SecurityDto;
using CarsApi.Application.Services;
using CarsApi.Application.Services.Impl;
using Microsoft.IdentityModel.Tokens;

namespace CarsApi.Application.security
{
    public class TokenService
    {
        private readonly string jwtKey;

        public TokenService(IConfiguration configuration)
        {
            jwtKey = configuration["JwtSettings:SecretKey"];
        }
        public string Generate(ResponseAuthDto dto)
        {
            var key = Encoding.UTF8.GetBytes(jwtKey); // array de bytes da chave do appsettings
            var handler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256); // chaves prara criar o token 1 chave de assinatura, formato de encripitacao

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(dto), // usuario do token
                SigningCredentials = credentials, // chaves de assinatura
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = "CarsApi", // gerador do token
                Audience = "CarsApiClient", // validador do token gerado
            };
            var token = handler.CreateToken(tokenDescriptor);
            var strToken = handler.WriteToken(token);
            return strToken;
        }
        private static ClaimsIdentity GenerateClaims(ResponseAuthDto dto)
        {
            var ci = new ClaimsIdentity();
            ci.AddClaim(new Claim(ClaimTypes.Name, dto.Name));
            ci.AddClaim(new Claim(ClaimTypes.Email, dto.Email));
            foreach (var role in dto.Roles)
            {
                ci.AddClaim(new Claim(ClaimTypes.Role, role.Name));
             }
            return ci;
         }
    }
}