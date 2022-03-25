using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Pessoa
    {
        public int idPessoa { get; set; }
        public string nmPessoa { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public byte[]? FotoPerfil { get; set; }
        public string? RedeSocial { get; set; }  
    }
}