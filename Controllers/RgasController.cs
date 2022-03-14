using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmoPatass.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RgasController : ControllerBase
    { private readonly DataContext _context;//Declaração
        private readonly IHttpContextAccessor _httpContextoAccessor;

        public RgasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Rga> r = await _context.Rgas.ToListAsync();
                return Ok(r);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}