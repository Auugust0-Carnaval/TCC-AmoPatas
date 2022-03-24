using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmoPatass
{
    public class PessoaFoto
    {
        public int IdPessoa { get; set; }
        public Pessoas Pessoas { get; set; }
        public byte[] ftPessoa { get; set; }
    }
}