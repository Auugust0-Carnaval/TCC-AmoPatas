using System;
using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Pets
    {
        public int IdAnimal { get; set; }//pk
        public string nmAnimal { get; set; }
        public DateTime dtPublicacao { get; set; }
        public DateTime dtAdocao { get; set; }
        public string cdAnimal { get; set; }
        public string UfAnimal { get; set; }
        public int Idade { get; set; }

        //fks
        public Porte Porte { get; set; }
        public int IdPorte { get; set; }//fk

        public Pessoas Pessoas { get; set; }
        public int IdPessoa { get; set; }
        public Racas Racas { get; set; }
        public int IdRaca { get; set; } 
        public  Categoria Categoria { get; set; }
        public int IdCategoria { get; set; } 
        public Situacoes Situacoes { get; set; }
        public int IdSituacao { get; set; } 
        public int idTutor { get; set; }
        public Sexo Sexo { get; set; }
        public int IdSexo { get; set; }
    }
}