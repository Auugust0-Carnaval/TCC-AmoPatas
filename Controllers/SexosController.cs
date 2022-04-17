using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TCC_AmoPatas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SexosController : ControllerBase // heranca da classe ControllerBase, herdando caracteristicas (metodos e etc)
    {
        private readonly DataContext _context; //variavel _context = sempre usaremos para acessa o banco
        private readonly IHttpContextAccessor _httpContextoAccessor;

        // Criando Construtor , para inicializar o contexto Declarado !
        public SexosController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; 
            _httpContextoAccessor = httpContextAccessor;
        }

        [HttpGet] // metodo HTTP de busca
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                List<Sexo> sex = await _context.Sexo.ToListAsync(); // acessa o contexto do banco de dados e adiciona em uma lista
                if(sex.Count.Equals(0)) // se não tiver nenhuma informação na busca é declarado uma mensagem
                {
                    throw new System.Exception("Não foi encotrado nenhum 'Sexo'"); // mensagem de badrequest (status:400)
                }
                return Ok(sex); //retorna valor de busca
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message); // exbibe mensagem de  declarada no try(syste.Exception)
            }
        }
    }
}