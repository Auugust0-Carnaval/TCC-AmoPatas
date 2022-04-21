using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;

namespace TCC_AmoPatas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PessoasFotosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor; //implemetando interface para propiedades de metodos HTTPS
        public PessoasFotosController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }


        [HttpGet]
        public async Task<IActionResult> GetFoto()
        {
            try
            {
                List<PessoaFoto> pf = _context.PessoaFoto.ToList();
                if (pf.Count == 0)
                    throw new System.Exception("Nenhuma foto encontrada : (");
                return Ok(pf);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //METODO DE INSERIR IMAGEN NO BANCO

        // [HttpPost]
        // public async Task<IActionResult> UploadImage(IList<IFormFile> arquivos)
        // {
        //     IFormFile imagemCarregada = arquivos.FirstOrDefault();
        //     if(imagemCarregada == null)
        //     {
        //         MemoryStream ms = new MemoryStream();
        //         imagemCarregada.OpenReadStream().CopyTo(ms);

        //         arquiv
        //     }

        // }








    }
}