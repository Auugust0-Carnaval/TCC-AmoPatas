using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Raca
    {
        public int IdRaca { get; set; }
        public Categoria Categoria { get; set; }
        public int IdCategoria { get; set; }
        public string dsRaca { get; set; }
    }
}