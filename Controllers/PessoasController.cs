using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AmoPatass
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        // Atributo global
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor;

        // Criando Construtor , para inicializar o contexto Declarado !
        public PessoasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        { 
            try
            {
                Pessoas p = await _context.Pessoas
                    .FirstOrDefaultAsync(pBusca => pBusca.idPessoa == id);
            
                return Ok(p);
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
                List<Pessoas> lista = await _context.Pessoas.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(Pessoas novaPessoa){
            try
            {
                await _context.Pessoas.AddAsync(novaPessoa);
                await _context.SaveChangesAsync();

                return Ok(String.Format("Pessoa: {0} adicionada com sucesso", novaPessoa.idPessoa));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pessoas novoPessoa)
        {
            try
            {
                _context.Pessoas.Update(novoPessoa);
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
                Pessoas pRemover = await _context.Pessoas
                    .FirstOrDefaultAsync(p => p.idPessoa == id);

                _context.Pessoas.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                
                return Ok(String.Format("id {0} da Pessoa, deletado com sucesso ! linhas Afetadas: {1} ", id, linhasAfetadas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
    }
}