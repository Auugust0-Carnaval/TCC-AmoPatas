using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using AmoPatass.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AmoPatass.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

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

        private void CriarHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var crip = new System.Security.Cryptography.HMACSHA512()) // metodo de criptografia 
            {
                PasswordSalt = crip.Key; // chave principal da criptografia 
                PasswordHash =  crip.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> PessoaExistente(string nome)
        {
            if(await _context.Pessoa.AnyAsync(x => x.nmPessoa.ToLower() == nome.ToLower()))
            {
                  return true;

            }  
            else
            {
                return false;

            } 
        }

        [AllowAnonymous]
        [HttpPost("Cadastrar")]

        public async Task<IActionResult> CadastrarPessoa(Pessoa Usuario)
        {
            try
            {
               if(await PessoaExistente(Usuario.nmPessoa))  
               throw new System.Exception(string.Format("Usuario:{0} já existente",Usuario.nmPessoa));

               CriarHash(Usuario.Password, out byte[] hash, out byte[]  salt);
               Usuario.Password = string.Empty;
               Usuario.PasswordHash = hash;
               Usuario.PasswordSalt = salt;

               await _context.Pessoa.AddAsync(Usuario);
               await _context.SaveChangesAsync();

               return Ok(string.Format("{0} adicionada com sucesso <3",Usuario.nmPessoa));
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
                Pessoa p = await _context.Pessoa
                .FirstOrDefaultAsync(pBusca => pBusca.IdPessoa == id);



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
                List<Pessoa> lista = await _context.Pessoa.ToListAsync();
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

    }
}
