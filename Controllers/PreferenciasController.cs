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

        //  [HttpGet("GetAll")]  //Preferencias sq
        //  public async Task<IActionResult> GetAllsqPreferencia()
        // {
        //     try
        //     {


        //         List<Preferencia> sqLista = await _context.Preferencia.ToListAsync();

        //         //Retorno da Lista de preferencias
        //         return Ok(sqLista);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }




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


        //  [HttpGet("GetAll")]  //Preferencias sq
        //  public async Task<IActionResult> GetAllsqPreferencia()
        // {
        //     try
        //     {


        //         List<Pet> sqLista = await _context.Pet.ToListAsync();

        //         .Include(r => r.Raca)

        //         //Retorno da Lista de preferencias
        //         return Ok(sqLista);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }







        // exbir a lista de pets de acordo com o filtro
        //   [HttpGet("{id}")] //buscar pelo id informado

        //      public async Task<IActionResult> addPreferencia(int id)
        //      {
        //          try
        //          {
        //             List<Pet> phLista = new List<Pet>();

        //              // List<Pet> pt= await _context.Pet.ToListAsync();
        //                phLista = await _context.Pet
        //               .Include(c => c.IdCategoria)
        //               .Include(s => s.IdSexo )
        //               .Include(pr => pr.IdPorte)
        //               .Include(r => r.IdRaca)
        //               .Include(p => p.Pets)

        //               .Where(p => p.IdAnimal == id).ToListAsync();
        //               return Ok(phLista);
        //          }
        //          catch (System.Exception ex)
        //          {
        //               return BadRequest(ex.Message);

        //          }
        //      }


          // [HttpGet("{id}")]
          // public async Task<ActionResult<Pet>> GetTodoItem(long id)
          // {
          //     var p = await _context.Pet.FindAsync(id);

          //     if (p == null)
          //     {
          //         return NotFound();
          //     }

          //     return p;
          // }

        //   [HttpPost]
        // public async Task<ActionResult<Pet>> PostTodoItem(Pet pet)
        // {
        //     _context.Pet.Add(pet);
        //     await _context.SaveChangesAsync();

        //     //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        //     return CreatedAtAction(nameof(GetTodoItem), new { id = pet.IdAnimal}, pet;
        // }


          //Buscar preferencias de acordo com o pet  --- post preferencia
        //  [HttpGet("{sqPreferencia}")]                               //Preferencia sq
        //   public async Task<IActionResult> GetSingle( int sq)
        //   {
        //     try
        //     {
        //       //List<Pet> p = await _context.Pet.ToListAsync();
        //        Pet p = await _context.Pet.FirstOrDefaultAsync(pet => pet.IdCategoria == sq);

        //         if(p.IdCategoria == sq) //if(p.IdCategoria == sq)
        //         {


        //         }
        //           return Ok(p);

        //          if(p.IdPorte == sq)
        //         {
        //              return Ok(p);
        //             throw new System.Exception("Porte");
        //         }

        //          if(p.IdRaca == sq)
        //         {
        //              return Ok(p);
        //             throw new System.Exception("raca");
        //         }


        //     }

        //      catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        //   }




        //  [HttpPost]
        // public async Task<IActionResult> Add( Preferencia sq){
        //     try
        //     {
        //         await _context.Preferencia.AddAsync(sq);
        //         await _context.SaveChangesAsync();


        //         return Ok(String.Format("Animal: {0} adicionado com sucesso", sq.IdCategoria
        //                           /* "IdAnimal: {0} adicionado com sucesso", sq.IdPorte, "Idcategoria: {0} adicionado com sucesso", novaP.IdCategoria */ ));
        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }










       //Filtrar uma preferencia por algum criterio e retornar o pets daqueles criterios



        //Buscar Personagem pelo {id}
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetPersonagem(int id)//retorna lista de personagem com id
        // {
        //     try
        //     {
        //         List<Pet> phLista = new List<Pet>();

        //         phLista = await _context.Pet
        //         .Include(p => p.Personagem)
        //         .Include(p => p.Habilidade)
        //          .Where(p => p.PersonagemId == id).ToListAsync();

        //        //Retorno da Lista de Personagens !
        //         return Ok(phLista);
        //     }
        //     catch (System.Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }





        // [HttpPost]
        // public async Task<IActionResult> Add(Preferencia sq){
        //     try
        //     {
        //         await _context.Preferencia.AddAsync(sq);
        //         await _context.SaveChangesAsync();

        //         return Ok(String.Format("Pessoa: {0} adicionada com sucesso", sq.sqPreferencia));

        //     }
        //     catch (Exception ex)
        //     {
        //         return BadRequest(ex.Message);
        //     }
        // }





    }

}
