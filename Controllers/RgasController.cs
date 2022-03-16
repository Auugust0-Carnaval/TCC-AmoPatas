using System.Net.Http.Headers;
using System.Security.Claims;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

                if(r.Count == 0 )
                    throw new System.Exception("Rga não encontrado");
               
                return Ok(r);
            }
            catch (System.Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Rga newRga, int id)
        {
            try
            {
                await _context.Rgas.AddAsync(newRga);


                if(newRga.IdRga == _context.Rgas.FindAsync(id))
               
                await _context.SaveChangesAsync();
                return Ok(newRga.IdRga);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}