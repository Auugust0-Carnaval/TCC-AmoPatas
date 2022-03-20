using System.Data;
using AmoPatass.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AmoPatass
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly DataContext _context;//Declaração
        private readonly IHttpContextAccessor _httpContextoAccessor;

        public CategoriasController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }

        [AllowAnonymous]    
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                List<Categoria> c = await _context.Categorias.ToListAsync();

                if(c.Count == 0 )
                    throw new System.Exception("Não foi encontado nenhuma categoria :(");
                return Ok(c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Categoria newCategoria)
        {
            try
            {
                await _context.Categorias.AddAsync(newCategoria);
                await _context.SaveChangesAsync();
                return Ok(string.Format("Categoria: {0} com Id: {1} , adicionada com sucesso", newCategoria.dsCategoria, newCategoria.IdCategoria));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpAsync(Categoria UpCategoria)
        {
            try
            {
                //string de conexao na variavel stconction
               String stconection = "Data Source= workstation id=DB-DS-AMOPATAS.mssql.somee.com;packet size=4096;user id=saaugustocarnaval;pwd=123456789;data source=DB-DS-AMOPATAS.mssql.somee.com;persist security info=False;initial catalog=DB-DS-AMOPATAS";
               SqlConnection connection = new SqlConnection(stconection);
               string sql = string.Format("SELECT dsCategoria FROM Categorias WHERE IdCategoria = {0}", UpCategoria.IdCategoria);
               connection.Open(); //abrindo conexao com a variavel instanciada com a string de conexao
               SqlCommand cmd = new SqlCommand(sql,connection); // buscando dsCategoria para colocar no StringFormat
               string nameCategory = Convert.ToString(cmd.ExecuteScalar()); // execudando comando e colocando valor de busca na variavel nameCategory
            
               _context.Categorias.Update(UpCategoria);
               int linhaAfetadas = await _context.SaveChangesAsync();
               return Ok(string.Format("A categoria {0}, foi alterada para {1}!",nameCategory, UpCategoria.dsCategoria ));
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}