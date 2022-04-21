using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AmoPatass;
using Microsoft.IdentityModel.Tokens;
using TCC_AmoPatas.Models;

// esse aruqiov não é "importante " é so um metodo que gera o token hihi
namespace TCC_AmoPatas.Services
{
    public static class TokenServices
    {
        public static string GenerateToken(Pessoa pessoa)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // Subject = new ClaimsIdentity(new[]
                // {
                //     new Claim(ClaimTypes.Email, pessoa.Email)
                //      new Claim(ClaimTypes.)
                // }),

                Expires = DateTime.UtcNow.AddHours(8), // o token esta definifo para durar 8 horas
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor); // aqui ele cria o token com as informações de criptografia e etc

            return tokenHandler.WriteToken(token); // retorna o token na funcão

        }

        
        
    }
}