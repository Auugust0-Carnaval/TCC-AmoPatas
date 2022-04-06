using AmoPatass;
using AmoPatass.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;



namespace AmoPatass
{
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
            //bunca na base de dados Pessoas com o mesmos nomes de registro cadastrado
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
        [HttpPost("Cadastrar")] //rota da Url

        public async Task<IActionResult> CadastrarPessoa(Pessoa Usuario)
        {
            try
            {
                //chamando metodo de verificação e colocando parametros de Pessoa
               if(await PessoaExistente(Usuario.nmPessoa))  
               throw new System.Exception(string.Format("Usuario:{0} já existente",Usuario.nmPessoa)); //exindo mensagem de pessoa já existente na base de dados

               CriarHash(Usuario.Password, out byte[] hash, out byte[]  salt); // criptografando senha do Usuario/Pessoa
               Usuario.Password = string.Empty;
               Usuario.PasswordHash = hash;
               Usuario.PasswordSalt = salt;

               await _context.Pessoa.AddAsync(Usuario); // adicionando nova Pessoa na base de dados
               await _context.SaveChangesAsync(); // salvando as informações de inserção

               return Ok(string.Format("{0} adicionada com sucesso <3",Usuario.nmPessoa)); // exibido mensagem de sucesso
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message); // exbido mensagem de conflito de "Usuario existente"
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

        private bool checkedPassowordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        [AllowAnonymous]
        [HttpPost("Autenticacao")]
        public async Task<IActionResult> AutenticarPessoa(Pessoa credencial)
        {
            try
            {
                Pessoa p = await _context.Pessoa
                    .FirstAsync(pcompare => pcompare.nmPessoa.ToLower().Equals(credencial.nmPessoa.ToLower()));
                if(p == null)
                {
                    throw new System.Exception("Pessoa não encontrada :(");
                }
                else if(!checkedPassowordHash(credencial.Password, p.PasswordHash, p.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta :(");
                }
                else
                {
                    p.DataAcesso = System.DateTime.Now; // inserção de data atual na propriedade Data acesso
                    _context.Pessoa.Add(p);
                    await _context.SaveChangesAsync();
                    return Ok(createToken(p));
                }

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        private string createToken(Pessoa pessoa)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, pessoa.IdPessoa.ToString()),
                new Claim(ClaimTypes.Name, pessoa.nmPessoa)
            };

        //Gerar nosso Token !
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_configuration.GetSection("ConfiguracaoToken:Chave").Value));
            //Criptografia !
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                //Detalhes do token !
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            //Escreva o token no retorno
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterPassword(Pessoa credential)
        {
            try
            {
                 Pessoa pessoa = await _context.Pessoa //Busca pessoa na base de dados
                       .FirstOrDefaultAsync(x => x.nmPessoa.ToLower().Equals(credential.nmPessoa.ToLower()));

                if(pessoa == null) //Se não achar nenhum usuario pelo logim, retorna mensagem
                    throw new System.Exception("Pessoa não encontrada");


                CriarHash(credential.Password, out byte[] hash, out byte[] salt);
                pessoa.PasswordHash = hash; //guardando hash na propriedade de Pessoa
                pessoa.PasswordSalt = salt; //guardando salt na propriedade de Pessoa

                _context.Pessoa.Update(pessoa);
                await _context.SaveChangesAsync(); //salva alterações na base de dados
                return Ok(string.Format("Senha alterada com sucesso")); 
            }
            catch (System.Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }











    }
}
