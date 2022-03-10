using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Rga
    {
        [Key]
        public int IdRga { get; set; }
        public string dsRga { get; set; }
        
    }
}