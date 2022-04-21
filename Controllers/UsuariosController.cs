using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AmoPatass.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TCC_AmoPatas.Models;
using TCC_AmoPatas.Services;

namespace TCC_AmoPatas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor;

        private IConfiguration _config;
        public UsuariosController(IConfiguration Configuration)
        {
            _config = Configuration;
            
        }

        /*[HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginDetalhes)
        {
            var usuarios = await _context.Usuarios.FindAsync();
            bool resultado = ValidarUsuario(loginDetalhes);
            if (resultado)
            {
                var tokenString = GerarTokenJWT();
                return Ok(new { token = tokenString });
            }
            else
            {
                return BadRequest(string.Format("Username ou senha inválidos"));
            }
        }*/

        //TODO outro metodo de geração de TOKEN-JWT (teste)

        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer,audience: audience,
            expires: DateTime.Now.AddMinutes(120),signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }


        public bool ValidarUsuario(User loginDetalhes)
        {

            // var user = UserRepositorie.get(usuarios.username, usuarios.Password)
            
            if (loginDetalhes.username == loginDetalhes.username  && loginDetalhes.Password.ToLower() == loginDetalhes.Password.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /*[HttpPost]
        public async Task<IActionResult> AddAsync(User newUsuario)
        {
            try
            {
                await _context.Usuarios.AddAsync(newUsuario); 
                await _context.SaveChangesAsync();

                return Ok(string.Format("{0} cadastrado com sucesso", newUsuario.username));
                
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

        //aqui é meotod para eu gera
        // [HttpPost("Autenticar")]
        // [AllowAnonymous] // ctrl + ; = commenta a linha
        // public async Task<IActionResult> Authenticate([FromBody] User usuarios)
        // {
        //     try
        //     {
        //         //busca o usuario no UserRepositorie (username, passoword)
        //         var user = UserRepositorie.get(usuarios.username, usuarios.Password);

        //         if(user == null) // verefica se exite algum usuario na repositorio
        //             throw new System.Exception("Usuario ou senha invalidos");

        //         // var token = TokenServices.GenerateToken(user); // gera o token com as propriedades de usuario (username e password)
        //         user.Password = "";
        //         return Ok(TokenServices.GenerateToken(user));
        //         // return Ok(string.Format("{0} seu token de autorização" + "\n{1}", user.username, token.ToString()));
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return NotFound(ex.Message);

        //     }
            
        // }

        // [HttpGet("anonymous")] //metodo de busca
        // [Route("anonymous")] // direcionamento de requisições
        // [AllowAnonymous] // acesso anomimo a esse metodo sem recisar de cripografia de autorização
        // public string Anonymous() => "Acesso anonimo funfou"; //resposta de busca

        [HttpGet("authenticated")] 
        // [Route("authenticated")] //esse metodo precisa de tokne para parecer essa mensagem
        [Authorize]// metodo necessida de autorização criptografico para ser acessado(usado)

        public string Authenticate() => string.Format("Autenticado com sucesso!");
    }
}