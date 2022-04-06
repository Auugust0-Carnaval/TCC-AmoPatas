using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmoPatass
{
    public class Raca
    {
        public int IdRaca { get; set; }
       
        [ForeignKey("IdCategoria")]
        public int IdCategoria { get; set; }
        public string dsRaca { get; set; }
    }
}