using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCC_AmoPatas.Models;
using TCC_AmoPatas.Services;

namespace TCC_AmoPatas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        //aqui é meotod para eu gera
        [HttpPost("Autenticar")]
        [AllowAnonymous] // ctrl + ; = commenta a linha
        public async Task<IActionResult> Authenticate([FromBody] User usuarios)
        {
            try
            {
                //busca o usuario no UserRepositorie (username, passoword)
                var user = UserRepositorie.get(usuarios.username, usuarios.Password);

                if(user == null) // verefica se exite algum usuario na repositorio
                    throw new System.Exception("Usuario ou senha invalidos");

                // var token = TokenServices.GenerateToken(user); // gera o token com as propriedades de usuario (username e password)
                user.Password = "";
                return Ok(TokenServices.GenerateToken(user));
                // return Ok(string.Format("{0} seu token de autorização" + "\n{1}", user.username, token.ToString()));
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);

            }
            
        }

        [HttpGet("anonymous")] //metodo de busca
        [Route("anonymous")] // direcionamento de requisições
        [AllowAnonymous] // acesso anomimo a esse metodo sem recisar de cripografia de autorização
        public string Anonymous() => "Acesso anonimo funfou"; //resposta de busca

        [HttpGet("authenticated")] 
        // [Route("authenticated")] //esse metodo precisa de tokne para parecer essa mensagem
        [Authorize]// metodo necessida de autorização criptografico para ser acessado(usado)

        public string Authenticate() => string.Format("Autenticado com sucesso!");
    }
}