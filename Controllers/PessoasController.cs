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
        private readonly IHttpContextAccessor _httpContextoAccessor; //implemetando interface para propiedades de metodos HTTPS

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
                Pessoa p = await _context.Pessoas
<<<<<<< HEAD
                    .FirstOrDefaultAsync(pBusca => pBusca.IdPessoa == id);

=======
                    .FirstOrDefaultAsync(pBusca => pBusca.idPessoa == id);
            
>>>>>>> 440f248d639515fde9d1e07415708f3856dbdc20
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
                List<Pessoa> lista = await _context.Pessoas.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(Pessoa novaPessoa){
            try
            {
                await _context.Pessoas.AddAsync(novaPessoa);
                await _context.SaveChangesAsync();

                return Ok(String.Format("Pessoa: {0} adicionada com sucesso", novaPessoa.IdPessoa));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pessoa novoPessoa)
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
                Pessoa pRemover = await _context.Pessoas
<<<<<<< HEAD
                    .FirstOrDefaultAsync(p => p.IdPessoa == id);
=======
                    .FirstOrDefaultAsync(p => p.idPessoa == id);
>>>>>>> 440f248d639515fde9d1e07415708f3856dbdc20

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
