using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmoPatass
{
    public class Pet
    {
      // [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdAnimal { get; set; }//pk
        public string nmAnimal { get; set; }
        public string dsAnimal { get; set; }
        public DateTime dtPublicacao { get; set; }
        public DateTime dtAdocao { get; set; }
        public string cdAnimal { get; set; }
        public string UfAnimal { get; set; }
        public int Idade { get; set; }


        // public List<Preferencia> prefencias { get; set; }


        //Siangui arrumo aqui  <3
        public int IdPorte { get; set; }//fk
        public int IdPessoa { get; set; }//


        // [ForeignKey("IdRaca")]
        public int IdRaca { get; set; }//


        // [ForeignKey("IdCategoria")]
        public int IdCategoria { get; set; }//

        // [ForeignKey("IdSituacao")]
        public int IdSituacao { get; set; }//

        //  [ForeignKey("IdTutor")]
        public int IdTutor { get; set; }//

        //  [ForeignKey(" IdSexo")]
        public int IdSexo { get; set; }//

        //  [ForeignKey("IdDoador")]
        public int IdDoador { get; set; }  //

  }
}
