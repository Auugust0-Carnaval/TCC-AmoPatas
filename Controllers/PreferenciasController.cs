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
       private Preferencias pf = new Preferencias();
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
                List<Preferencias> pfLista = await _context.Preferencias.ToListAsync();

                if(pfLista == null)
                    throw new System.Exception("Não encontrado Pets com estas categorias");
                //Retorno da Lista de preferencias
                return Ok(pfLista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //exbir a lista de pets de acordo com o filtro
        //   [HttpGet("{id}")]//buscar pelo id informado

        //  public async Task<IActionResult> GetSingle(int id)
        //  {
        //      try
        //      {
        //           Pets p = await _context.Pets
        //           .Include( c => c.Categorias )
        //           .Include(s => s.Sexo)
        //           .Include(pt => pt.Porte)
        //           .Include(r => r.Racas)
        //           .ThenInclude(p => p.Pessoas)
        //           .FirstOrDefaultAsync(pbusca => pbusca.Id == id);
        //           return Ok(p);
        //      }
        //      catch (System.Exception ex)
        //      {
        //           return BadRequest(ex.Message);

        //      }
        //  }





    }

}
