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
        
    }
}