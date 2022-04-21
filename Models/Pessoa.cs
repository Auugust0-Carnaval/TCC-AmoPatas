using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmoPatass
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        public string nmPessoa { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public byte[]? FotoPerfil { get; set; }
        public string? RedeSocial { get; set; }
        public string Password {get; set;} // senha de acesso
    }
}
