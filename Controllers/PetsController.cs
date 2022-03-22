using System.Collections.Generic;
using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TCC_AmoPatas
{
    [ApiController]//declara essa classe como controller
    [Route("[controller]")]// define uma rota na classe PetsController porem só a valido ["Pets"]Controller
    public class PetsController : ControllerBase
    {
        private readonly DataContext _context; //variavel _context = sempre usaremos para acessa o banco
        private readonly IHttpContextAccessor _httpContextoAccessor;

        // Criando Construtor , para inicializar o contexto Declarado !
        public PetsController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }

        [HttpGet]
        //GetAl = nome do metodo
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Pets> petzin = await _context.Pets.ToListAsync();
                //se der ruiim executa o if
                if(petzin.Count == 0)
                {
                    throw new System.Exception("Nenhuma informação encontrada");
                }
                //se der bam retorna o resultado buscado
                return Ok(petzin);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        { 
            try
            {
               Pets p = await _context.Pets.FirstOrDefaultAsync(pet => pet.IdAnimal == id);
               if(p.IdAnimal != id )//coount não funfa pq não é list
               {
                   throw new System.Exception("fofeu");
               }
                    
            
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Pets novoAnimal){
            try
            {
                await _context.Pets.AddAsync(novoAnimal);
                await _context.SaveChangesAsync();

                return Ok(String.Format("Animal: {0} adicionado com sucesso", novoAnimal.IdAnimal));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        
    }
}