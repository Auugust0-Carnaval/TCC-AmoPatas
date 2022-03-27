using Microsoft.AspNetCore.Mvc;

namespace TCC_AmoPatas.Controllers
{
   [ApiController]
  [Route("[Controller]")]
      public class TesteController : ControllerBase
    {
          [HttpGet]  //Preferencias sq
         public  String GetAllTeste()
        {


                //Retorno da Lista de preferencias
                return ("Olá, mundo");



        }
    }
}
