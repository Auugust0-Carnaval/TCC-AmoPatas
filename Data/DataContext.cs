using Microsoft.EntityFrameworkCore;

namespace AmoPatass.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }




         public DbSet<AnimalFoto> AnimalFoto { get; set; }//Pega as classes em models e transforma em tabelas
         public DbSet<PessoaFoto> PessoaFoto {get; set;}//Classe PessoaFoto vira tabela PessoasFotos
         public DbSet<Categoria> Categoria { get; set; }
         public DbSet<Interessado> Interessado { get; set; }
         public DbSet<Pessoa> Pessoa { get; set; }
         public DbSet<Pet> Pet { get; set; }
         public DbSet<Porte> Porte { get; set; }
         public DbSet<Preferencia> Preferencia { get; set; }
         public DbSet<Raca> Raca { get; set; }
         public DbSet<Sexo> Sexo { get; set; }
         public DbSet<Situacao> Situacoe { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {

            modelBuilder.Entity<AnimalFoto>()
                .HasOne<Pet>()
                .WithMany()
                .HasForeignKey(p => p.IdAnimal);

            modelBuilder.Entity<AnimalFoto>()
                .HasKey(anf => new {anf.IdAnimalFoto});

            modelBuilder.Entity<Categoria>()
                .HasKey(c => new{c.IdCategoria});

            modelBuilder.Entity<Interessado>()
                .HasKey(i => new{i.IdPessoa, i.idAnimal});


            modelBuilder.Entity<Pessoa>()


                .HasKey(p => new{p.IdPessoa});




            modelBuilder.Entity<Pet>()
                .HasKey(pt => new{pt.IdAnimal});

            modelBuilder.Entity<Raca>()
                .HasKey(r => new{r.IdRaca});


            modelBuilder.Entity<Sexo>()
                .HasKey(s => new{s.IdSexo});

            modelBuilder.Entity<Situacao>()
                .HasKey(st => new{st.IdSituacao});

            modelBuilder.Entity<Porte>()
                .HasKey(por => new {por.IdPorte});

            modelBuilder.Entity<Preferencia>
            (pr =>
                {
                    pr.HasNoKey();
                }
            );

            modelBuilder.Entity<PessoaFoto>
            (pf =>
                {
                    pf.HasNoKey();
                }
            );
         }
    }
}
