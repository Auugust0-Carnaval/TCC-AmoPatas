using System.Data;
using AmoPatass.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AmoPatass
{
    [Authorize]
    [EnableCors("CorsApi")]
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : Controller // herança da classe ControllerBase para ter as mesma caracteristicas e metodos
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor;

        public CategoriasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //Declaração do classe de contexto de dados na variavel _context
            _httpContextoAccessor = httpContextAccessor; //implemetando interface para propiedades de metodos HTTPS
        }

        [AllowAnonymous] //pode ter acesso a esse método sendo anonimato
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Categoria> c = await _context.Categoria.ToListAsync(); //busca informações do banco e tranforma em lista

                if (c.Count == 0) // conta  as linhas de busca, se tiver zero linhas, exibe a mensagem
                    throw new System.Exception("Não foi encontrado nenhuma categoria !");
                return Ok(c); // caso tenha algum valor na busca retorna valor
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message); // exibe ex.Message
            }
        }

        [HttpPost("InserirCategoria")]
        public async Task<IActionResult> AddAsync(Categoria newCategoria)
        {
            try
            {
                await _context.Categoria.AddAsync(newCategoria); //vai no contexto da base de dados e insere informações
                await _context.SaveChangesAsync(); //salva as informações inseridas
                //retorna uma mensagem em formato de string (String.Format()) concatenando a nova contegoria inserida com ID e descricao(dsCategoria)
                return Ok(string.Format("Categoria: {0} com Id: {1} , adicionada com sucesso", newCategoria.dsCategoria, newCategoria.IdCategoria));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message); //retorna badrequest porem não declarei nada :(
            }
        }

        [HttpPut] //metodo de alteração de informações
        public async Task<IActionResult> UpAsync(Categoria UpCategoria)
        {
            try
            {
                //string de conexao na variavel stconction
                String stconection = "Data Source= workstation id=DB-DS-AMOPATAS.mssql.somee.com;packet size=4096;user id=saaugustocarnaval;pwd=123456789;data source=DB-DS-AMOPATAS.mssql.somee.com;persist security info=False;initial catalog=DB-DS-AMOPATAS";
                SqlConnection connection = new SqlConnection(stconection);
                string sql = string.Format("SELECT dsCategoria FROM Categorias WHERE IdCategoria = {0}", UpCategoria.IdCategoria); //scritpt de busca
                connection.Open(); //abrindo conexao com a variavel instanciada com a string de conexao
                SqlCommand cmd = new SqlCommand(sql, connection); // buscando dsCategoria para colocar no StringFormat
                string nameCategory = Convert.ToString(cmd.ExecuteScalar()); // execudando comando e colocando valor de busca na variavel nameCategory

                _context.Categoria.Update(UpCategoria);//faz a alteração das informações inseridas na coluna desejada
                int linhaAfetadas = await _context.SaveChangesAsync(); //mostra as linhas afetadas na base de dados

                //retorna mensagem de sucesso com formato de string, exibindo valor "antigo" da coluna e valor "novo" (alterado) da coluna
                return Ok(string.Format("A categoria {0}, foi alterada para {1}!", nameCategory, UpCategoria.dsCategoria));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message); // não declarei nada caso tenha status: 400 badrequest
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                Categoria cRemove = await _context.Categoria
                    .FirstOrDefaultAsync(ct => ct.IdCategoria == id); //instanciando um valor buscado na base de dados (IdCategoria) na variavel "cRemove"

                if (cRemove == null) // caso o IdCategoria inserido na url para a busca seja null = "nulo" é informado uma mensagem
                {
                    throw new System.Exception("Categoria inserida não existe para ser excluida !");
                }

                _context.Categoria.Remove(cRemove); // remove as informações desejadas na base de dados
                int linhasAfetadas = await _context.SaveChangesAsync(); // exibi linha afetadas após execução

                //retorna mensagem de sucesso em formato de string, concatenando variavel(cRemove) exibindo descrição da categoria (dsCategoria)
                return Ok(string.Format("A Categoria : {0}, foi removida com sucesso!", cRemove.dsCategoria));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message); // exibe mensagem definia no try(system.Exception)
            }
        }
    }
}
