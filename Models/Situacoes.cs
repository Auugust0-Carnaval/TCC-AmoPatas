using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Situacoes
    {
        [Key]
        public int IdSituacao { get; set; }
        public string dsSituacao { get; set; }
        
    }
}