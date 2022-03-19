using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmoPatass
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;//Declaração
        private readonly IHttpContextAccessor _httpContextoAccessor;

        public CategoriasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Categoria> c = await _context.Categorias.ToListAsync();

                if(c.Count == 0 )
                    throw new System.Exception("Não foi encontado nenhuma categoria :(");
                return Ok(c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}