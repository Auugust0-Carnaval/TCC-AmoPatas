using System;
using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Pets
    {
        public int IdAnimal { get; set; }//pk
        public string nmAnimal { get; set; }
        public string dsAnimal { get; set; }
        public DateTime dtPublicacao { get; set; }
        public DateTime dtAdocao { get; set; }
        public string cdAnimal { get; set; }
        public string UfAnimal { get; set; }
        public int Idade { get; set; }

        //fks
        public Rga Rga { get; set; }
        public int? IdRga { get; set; } //fk
        public Porte Porte { get; set; }
        public int IdPorte { get; set; }//fk

        public Pessoas Pessoas { get; set; }
        public int IdPessoa { get; set; }

        public Racas Racas { get; set; }
        public int IdRaca { get; set; } //fk
        public  Categoria Categoria { get; set; }
        public int IdCatetegoria { get; set; } //fk
        public Situacoes Situacoes { get; set; }
        public int IdSituacao { get; set; } //fk

        public Sexo Sexo { get; set; }
        public int IdSexo { get; set; }
    }
}