using System;
using System.ComponentModel.DataAnnotations;

namespace AmoPatass
{
    public class Pet
    {
        public int IdAnimal { get; set; }//pk
        public string nmAnimal { get; set; }
        public string dsAnimal { get; set; }
        public DateTime dtPublicacao { get; set; }
        public DateTime dtAdocao { get; set; }
        public string cdAnimal { get; set; }
        public string UfAnimal { get; set; }
        public int Idade { get; set; }

        //Siangui arrumo aqui  <3
        public int IdPorte { get; set; }//fk
        public int IdPessoa { get; set; }//
        public int IdRaca { get; set; }//
        public int IdCategoria { get; set; }//
        public int IdSituacao { get; set; }//
        public int IdTutor { get; set; }//
        public int IdSexo { get; set; }//
        public int IdDoador { get; set; }  //
  }
}
