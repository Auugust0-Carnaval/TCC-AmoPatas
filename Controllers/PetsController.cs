using System.Collections.Generic;
using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Security.Claims;
namespace TCC_AmoPatas
{
    [ApiController]//declara essa classe como controller
    [Route("[controller]")]// define uma rota na classe PetsController porem só a valido ["Pets"]Controller
    public class PetsController : ControllerBase
    {
        private readonly DataContext _context; //variavel _context = sempre usaremos para acessa o banco
        private readonly IHttpContextAccessor _httpContextoAccessor;

        // Criando Construtor , para inicializar o contexto Declarado !
        public PetsController(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context; //inicialização do atributo
            _httpContextoAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpGet]
        //GetAll = nome do metodo
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Pet> petzin = await _context.Pet.ToListAsync();
                //se der ruiim executa o if
                if(petzin.Count == 0)
                {
                    throw new System.Exception("Nenhuma informação encontrada");
                }
                //se der bam retorna o resultado buscado
                return Ok(petzin);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
               Pet p = await _context.Pet.FirstOrDefaultAsync(pet => pet.IdAnimal == id);
               if(p.IdAnimal != id )//coount não funfa pq não é list
               {
                   throw new System.Exception("fofeu");
               }


                return Ok(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Pet novoAnimal)
        {
            try
            {
                await _context.Pet.AddAsync(novoAnimal);
              int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(String.Format("Animal: {0} adicionado com sucesso", novoAnimal.nmAnimal));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pet newPet)
        {
            try
            {
                String connectionData = "Data Source= workstation id=DB-DS-AMOPATAS.mssql.somee.com;packet size=4096;user id=saaugustocarnaval;pwd=123456789;data source=DB-DS-AMOPATAS.mssql.somee.com;persist security info=False;initial catalog=DB-DS-AMOPATAS";
                SqlConnection connection = new SqlConnection(connectionData);
                String querySql = string.Format("SELECT nmAnimal FROM Pets WHERE IdAnimal = {0}", newPet.IdAnimal,connection);
                connection.Open();
                SqlCommand cmd = new SqlCommand(querySql,connection);
                string oldPet = Convert.ToString(cmd.ExecuteScalar());

                _context.Pet.Update(newPet);
                 await _context.SaveChangesAsync();

                return Ok(String.Format("{0} teve dados alterados",oldPet));
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
                Pet pRemover = await _context.Pet
                    .FirstOrDefaultAsync(p => p.IdAnimal == id);

                _context.Pet.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(String.Format("id {0} do Animal , deletado com sucesso ! linhas Afetadas: {1} ", id, linhasAfetadas));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
