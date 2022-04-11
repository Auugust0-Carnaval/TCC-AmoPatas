using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AmoPatass;
using Microsoft.IdentityModel.Tokens;

namespace TCC_AmoPatas.Services
{
    public  static class TokenServices
    {
        public static string GenerateToken(Pessoa pessoa)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, pessoa.Email.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, pessoa.IdPessoa.ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
        
    }
}