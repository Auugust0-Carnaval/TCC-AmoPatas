
using System.ComponentModel.DataAnnotations;

namespace AmoPatass 
{
    public class AnimaisFoto
    {
        [Key]
        public int IdAnimalFoto { get; set; }
        public Pets Pets { get; set; }
        public int IdAnimal { get; set; }
        public byte[] ftAnimal { get; set; }

    }
}