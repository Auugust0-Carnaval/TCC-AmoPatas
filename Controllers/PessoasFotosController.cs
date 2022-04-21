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

        [HttpPost]
        public IActionResult UploadImage(IList<IFormFile> arquivos)
        {
            try
            {
                IFormFile imagemCarregada = arquivos.FirstOrDefault();
                if (imagemCarregada == null)
                {
                    MemoryStream ms = new MemoryStream();
                    imagemCarregada.OpenReadStream().CopyTo(ms);

                    PessoaFoto foto = new PessoaFoto()
                    {
                        Descricao = imagemCarregada.FileName,
                        ftPessoa = ms.ToArray(),
                        contentType = imagemCarregada.ContentType
                    };
                    _context.PessoaFoto.Add(foto);
                    _context.SaveChanges();

                }
                return Ok("Foto adicionada com sucesso :)");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")] //BUSCA FOTO PELO IdPessoaFoto

        public IActionResult GetIdFoto(int id)
        {
            PessoaFoto pf = _context.PessoaFoto.FirstOrDefault(p => p.IdPessoa == id);

            return File(pf.ftPessoa, pf.contentType);
        }








    }
}