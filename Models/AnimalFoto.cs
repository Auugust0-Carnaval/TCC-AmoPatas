
using System.ComponentModel.DataAnnotations;

namespace AmoPatass 
{
    public class AnimalFoto
    {
        [Key]
        public int IdAnimalFoto { get; set; }
        public Pet Pets { get; set; }
        public int IdAnimal { get; set; }
        public byte[] ftAnimal { get; set; }

    }
}