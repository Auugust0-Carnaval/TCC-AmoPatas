using Microsoft.EntityFrameworkCore;

namespace AmoPatass.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
<<<<<<< HEAD

        }
=======
            
        }  
>>>>>>> 440f248d639515fde9d1e07415708f3856dbdc20
         public DbSet<AnimalFoto> AnimaisFoto { get; set; }//Pega as classes em models e transforma em tabelas
         public DbSet<PessoaFoto> PessoasFotos {get; set;}//Classe PessoaFoto vira tabela PessoasFotos
         public DbSet<Categoria> Categorias { get; set; }
         public DbSet<Interessado> Interessados { get; set; }
         public DbSet<Pessoa> Pessoas { get; set; }
         public DbSet<Pet> Pets { get; set; }
         public DbSet<Porte> Porte { get; set; }
         public DbSet<Preferencia> Preferencias { get; set; }
         public DbSet<Raca> Racas { get; set; }
         public DbSet<Sexo> Sexo { get; set; }
         public DbSet<Situacao> Situacoes { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
<<<<<<< HEAD

=======
            
>>>>>>> 440f248d639515fde9d1e07415708f3856dbdc20
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
<<<<<<< HEAD
                .HasKey(p => new{p.IdPessoa});
=======
                .HasKey(p => new{p.idPessoa});
>>>>>>> 440f248d639515fde9d1e07415708f3856dbdc20

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
