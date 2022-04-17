using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;

namespace TCC_AmoPatas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SituacoesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextoAccessor; //implemetando interface para propiedades de metodos HTTPS

        public SituacoesController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }


        // [HttpGet]
       /* public async Task<IActionResult> GetAllAysnc()
        {
            List<Situa>


        /* Desenvolvimento
        *  obs: Construção de Situações
        */


    }
}
