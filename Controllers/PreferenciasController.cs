using System.Collections.Generic;
using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TCC_AmoPatas.Controllers

{
  [ApiController]
  [Route("[Controller]")]
    public class PreferenciasController : ControllerBase
    {
        private Preferencia pf = new Preferencia();
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor;

           public PreferenciasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }



        //Listar todas as preferências

           [HttpGet("GetAll")]
         public async Task<IActionResult> GetAllsqPreferencia()
        {
            try
            {
                List<Preferencia> pfLista = await _context.Preferencias.ToListAsync();
                //Retorno da Lista de preferencias
                return Ok(pfLista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //exbir a lista de pets de acordo com o filtro
          //  [HttpGet("{id}")] //buscar pelo id informado

          // public async Task<IActionResult> GetSingle(int id)
          // {
          //     try
          //     {
          //          Pets pt = await _context.Pets
          //          .Include( c => c.Categorias )
          //          .Include(s => s.Sexo)
          //          .Include(por => por.Porte)
          //          .Include(r => r.Racas)
          //          .ThenInclude(p => p.Pessoas)
          //          .FirstOrDefaultAsync(pbusca => pbusca.Id == id);
          //          return Ok(pt);
          //     }
          //     catch (System.Exception ex)
          //     {
          //          return BadRequest(ex.Message);

          //     }
          // }





    }

}
