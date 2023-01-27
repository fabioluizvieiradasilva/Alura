using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Models;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public Token CreateToken(IdentityUser<int> usuario)
        {
            Claim[] direitoUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString())
            };

            var chave = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("0g0fdg0ggdf0gfdg0dfgdf0gdf0gfdgdfg0dfgdf0g0dfgdf"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    claims: direitoUsuario,
                    signingCredentials: credenciais,
                    expires: DateTime.UtcNow.AddHours(1)
                    );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new Token(tokenString);
        }
    }
}
