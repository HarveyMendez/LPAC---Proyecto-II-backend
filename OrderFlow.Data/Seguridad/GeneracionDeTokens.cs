using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderFlow.Data.Interfaces;
using OrderFlow.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderFlow.Data.Seguridad
{
    public class GeneracionDeTokens : ITokenService
    {
        private readonly IConfiguration _config;

        public GeneracionDeTokens(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GenerarTokenAsync(Empleado empleado)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, empleado.id_empleado.ToString()),
                new Claim(ClaimTypes.Name, empleado.nombre_usuario),
                new Claim(ClaimTypes.Role, empleado.Rol?.nombre_rol ?? "Usuario")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expiracion,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GenerarRefreshTokenAsync(Empleado empleado)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:RefreshKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.NameIdentifier, empleado.id_empleado.ToString()) },
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<int> ValidarTokenAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var validation = await handler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            });

            if (!validation.IsValid)
                throw new SecurityTokenException("Token inválido");

            var claim = validation.ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return int.Parse(claim?.Value ?? "0");
        }

    }
}
