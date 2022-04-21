using System.Collections.Generic;
using AmoPatass;
using AmoPatass.Data;
using AmoPatass.Models.Enums;
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

        //METODOS GETNAME TODAS CLASSES

        [HttpGet]
        [Route("{name}")] // CATEGORIAS
        public async Task<IActionResult> CategorynameAsyncs2(string name)
        {
            Categoria ct = await _context.Categoria.FirstOrDefaultAsync(c => c.dsCategoria == name);

            return Ok(ct);
        }

        // [HttpGet]
        // [Route("{name}")] // PESSOAS
        // public async Task<IActionResult> PessoaNomeGetAsync(string name)
        // {
        //     Pessoa ps = await _context.Pessoa.FirstOrDefaultAsync(p => p.nmPessoa == name);

        //     return Ok(ps);
        // }

        // [HttpGet]
        // [Route("{name}")] // PETS
        // public async Task<IActionResult> GetPetName(string name)
        // {
        //     Pet ct = await _context.Pet.FirstOrDefaultAsync(c => c.nmAnimal == name);

        //     return Ok(ct);
        // }

        // [HttpGet]
        // [Route("{name}")] // RACAS
        // public async Task<IActionResult> NameCategoria(string name)
        // {
        //     Raca ct = await _context.Raca.FirstOrDefaultAsync(c => c.dsRaca == name);

        //     return Ok(ct);
        // }
    }
}
