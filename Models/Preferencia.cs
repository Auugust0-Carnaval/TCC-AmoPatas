using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace AmoPatass
{
    public class Preferencia
    {
        public int IdPessoa { get; set; }

        [ForeignKey("IdPessoa")]

        public int sqPreferencia { get; set; }

        [ForeignKey("IdPorte")]
        public int IdPorte { get; set; }

        [ForeignKey("IdSexo")]
        public int IdSexo { get; set; }

        public DateTime mtPreferencia { get; set; }

        [ForeignKey("IdCategoria")]
        public int IdCategoria { get; set; }


        //raça

        // public int IdRaca { get; set; }

        // [ForeignKey("IdRaca")]
        // public Racas Racas { get; set; }



    }
}
