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


        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor;

           public PreferenciasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }



        //Listar todas as preferências

         [HttpGet("GetAll")]  //Preferencias sq
         public async Task<IActionResult> GetAllsqPreferencia()
        {
            try
            {


                List<Preferencia> sqLista = await _context.Preferencia.ToListAsync();

                //Retorno da Lista de preferencias
                return Ok(sqLista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //   [HttpGet]
        //   public async Task<IActionResult> GetAll(Preferencias sq)
        // {
        //     try
        //     {
        //         List<Porte> q = await _context.Porte.ToListAsync();
        //         //se der ruiim executa o if
        //         if(q.Count == 0)
        //         {
        //             throw new System.Exception("Nenhuma informação encontrada");
        //         }
        //         //se der bam retorna o resultado buscado
        //         return Ok(q);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }


        //exbir a lista de pets de acordo com o filtro
            // [HttpGet("{id}")] //buscar pelo id informado

            // public async Task<IActionResult> GetSingle(int id)
            // {
            //     try
            //     {
            //          List<Pets> pt = await _context.Pets.ToListAsync();
            //          .Include(c => c.Categoria)
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




        //Filtrar uma preferencia por algum criterio e retornar o pets daqueles criterios

        //  [HttpGet]

        // public IActionResult Get



    }

}
