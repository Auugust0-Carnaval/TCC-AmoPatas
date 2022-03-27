using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TCC_AmoPatas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RacasController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor; //implemetando interface para propiedades de metodos HTTPS
        public RacasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Raca r = await _context.Raca
                    .FirstOrDefaultAsync(rBusca => rBusca.IdRaca == id);

                return Ok(r);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Raca> lista = await _context.Raca.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(Raca novaRaca){
            try
            {
                await _context.Raca.AddAsync(novaRaca);
                await _context.SaveChangesAsync();

                return Ok(String.Format("Raca: {0} adicionada com sucesso", novaRaca.IdRaca));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Raca novoRaca)
        {
            try
            {
                _context.Raca.Update(novoRaca);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(String.Format("Atualizado com sucesso ! linhas Afetadas: {0} ", linhasAfetadas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Raca rRemover = await _context.Raca
                    .FirstOrDefaultAsync(r => r.IdRaca == id);

                _context.Raca.Remove(rRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(String.Format("id {0} da Raca, deletado com sucesso ! linhas Afetadas: {1} ", id, linhasAfetadas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
