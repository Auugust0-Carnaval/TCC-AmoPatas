using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations.Schema;

namespace AmoPatass
{
    public class Preferencia
    {
<<<<<<< HEAD
=======
        public Pessoa Pessoas { get; set; }
>>>>>>> 440f248d639515fde9d1e07415708f3856dbdc20
        public int IdPessoa { get; set; }

        [ForeignKey("IdPessoa")]
        public Pessoa Pessoa { get; set; }

        public int sqPreferencia { get; set; }
        public int IdPorte { get; set; }

        [ForeignKey("IdPorte")]
        public Porte Porte { get; set; }

        public int IdSexo { get; set; }

        [ForeignKey("IdSexo")]
        public Sexo Sexo { get; set; }

        public DateTime mtPreferencia { get; set; }

        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }


        //raça
<<<<<<< HEAD

        // public int IdRaca { get; set; }

        // [ForeignKey("IdRaca")]
        // public Racas Racas { get; set; }

=======
        public Raca Racas { get; set; }
        public int IdRaca { get; set; }
>>>>>>> 440f248d639515fde9d1e07415708f3856dbdc20

    }
}
