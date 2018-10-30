using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models.Usuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace ApiBodas.Controllers
{
   // [Route("api/[controller]")]
   [Route("/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IRepositorioWrapper Repositorio { get; }

        public LoginController(IRepositorioWrapper rw)
        {
            Repositorio = rw;
        }

        [HttpPost]
        public IActionResult PostLogin(Usuario usuario)
        {
            // Validar el nombre de usuario

            // Validar el password

            if(!true)
            {
                return Unauthorized();
            }
            else
            {
                usuario.Password = ":)";

                var token = GenerarToken(usuario);

                return Ok(new
                {
                    ok = true,
                    usuario = usuario,
                    token = token,
                    id = usuario.Id,
               
                });
            }
        }

        public string GenerarToken(Usuario usuario)
        {
            var claveSecreta = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superCretetdfadfgdfgdgwefrwR54WE#43d#$%@13"));
            var credencialFirma = new SigningCredentials(claveSecreta, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(ClaimTypes.Role, usuario.Role.Nombre)
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:44392",
                audience: "https://localhost:44392",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credencialFirma
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;

        }
    }
}