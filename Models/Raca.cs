using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmoPatass
{
    public class Raca
    {
        public int IdRaca { get; set; }
        public int IdCategoria { get; set; }

        // [ForeignKey("IdCategoria")]

        public Categoria Categoria { get; set; }
        public string dsRaca { get; set; }
    }
}
