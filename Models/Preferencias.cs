using Microsoft.EntityFrameworkCore;

namespace AmoPatass
{
    public class Preferencias
    {
        public Pessoas Pessoas { get; set; }
        public int IdPessoa { get; set; }
        public int sqPreferencia { get; set; }
        public Porte Porte { get; set; }
        public int IdPorte { get; set; }
        public Sexo Sexo { get; set; }
        public int IdSexo { get; set; }
        public DateTime mtPreferencia { get; set; }
        public Categoria Categoria { get; set; }
        public int IdCategoria { get; set; }
        
    }
}