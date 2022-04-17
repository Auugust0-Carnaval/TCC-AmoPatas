using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TCC_AmoPatas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PortesController : ControllerBase
    {
        private readonly DataContext _context; //variavel _context = sempre usaremos para acessar o banco
        private readonly IHttpContextAccessor _httpContextoAccessor;

        // Criando Construtor , para inicializar o contexto Declarado !
        public PortesController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetallAsync()
        {
            try
            {
                List<Porte> portAll = await _context.Porte.ToListAsync();
                if(portAll.Count == 0)
                    throw new System.Exception("Não foi encontrado nenhum Porte :(");
                return Ok(portAll);
                               
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}