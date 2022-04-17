using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Data.SqlClient;
using TCC_AmoPatas;
using System.Security.Cryptography;
using TCC_AmoPatas.Services;

namespace AmoPatass
{
    [Authorize] // classe de controler de acesso aos metodos HTTP
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        // Atributo global
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;
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
                Pessoa p = await _context.Pessoa
                .FirstOrDefaultAsync(pBusca => pBusca.IdPessoa == id);
                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Pessoa> lista = await _context.Pessoa.ToListAsync();

                if(lista.Count.Equals(0))
                    throw new System.Exception("Não possui nenhuma pessoa cadastrada :(");
                return Ok(lista);
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
                _context.Pessoa.Update(novoPessoa);
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
                Pessoa pRemover = await _context.Pessoa

                    .FirstOrDefaultAsync(p => p.IdPessoa == id);
                _context.Pessoa.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(String.Format("id {0} da Pessoa, deletado com sucesso ! linhas Afetadas: {1} ", id, linhasAfetadas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> Add(Pessoa newPessoa)
        {
            try
            {
                newPessoa.Password = encryptPass.CalculaHash(newPessoa.Password);
                await _context.Pessoa.AddAsync(newPessoa);
                await _context.SaveChangesAsync();

                 return Ok(string.Format("{0} foi adicionada foi adicionada com sucesso :)", newPessoa.nmPessoa));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        /*[AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarPessoa([FromBody] Pessoa credenciais)
        {
            try
            {
                var pessoa = await _context.Pessoa.FindAsync(credenciais.Email, credenciais.Password);
                if(pessoa == null)
                    return NotFound(new {message = "Usuario ou senha inválido :("});

                var token = TokenServices.GenerateToken(pessoa);
                pessoa.Password = "";
                
                return Ok(string.Format("{0}" + "\n{1}", pessoa, token));
            }
            catch (System.Exception)
            { 
                throw;
            }
            
        }*/
    }
    
}
