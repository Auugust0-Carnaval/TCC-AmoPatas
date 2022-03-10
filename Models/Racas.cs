using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Racas
    {
        public Categoria Categoria { get; set; }
        public int IdCategoria { get; set; }
        
        [Key]
        public int IdRaca { get; set; }
        public string dsRaca { get; set; }
    }
}