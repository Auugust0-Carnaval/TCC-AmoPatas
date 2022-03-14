using Microsoft.EntityFrameworkCore;

namespace AmoPatass.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }  

         public DbSet<AnimaisFoto> AnimaisFotos { get; set; }
         public DbSet<Categoria> Categorias { get; set; }
         public DbSet<Interessados> Interessados { get; set; }
         public DbSet<Pessoas> Pessoas { get; set; }
         public DbSet<Pets> Pets { get; set; }
         public DbSet<Porte> Portes { get; set; }
         public DbSet<Preferencias> Preferencias { get; set; }
         public DbSet<Racas> Racas { get; set; }
         public DbSet<Rga> Rgas { get; set; }
         public DbSet<Sexo> Sexos { get; set; }
         public DbSet<Situacoes> Situacoes { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
            
            modelBuilder.Entity<AnimaisFoto>()
                .HasOne<Pets>()
                .WithMany()
                .HasForeignKey(p => p.IdAnimal);

            modelBuilder.Entity<AnimaisFoto>()
                .HasKey(anf => new {anf.IdAnimalFoto});

            modelBuilder.Entity<Categoria>()
                .HasKey(c => new{c.IdCatetegoria});

            modelBuilder.Entity<Interessados>()
                .HasKey(i => new{i.IdPessoa, i.idAnimal});

            modelBuilder.Entity<PessoaFoto>()
                .HasKey(pf => new{pf.IdPessoa});

            modelBuilder.Entity<Pessoas>()
                .HasKey(p => new{p.idPessoa});

            modelBuilder.Entity<Pets>()
                .HasKey(pt => new{pt.IdAnimal});

            modelBuilder.Entity<Racas>()
                .HasKey(r => new{r.IdRaca});

            modelBuilder.Entity<Rga>()
                .HasKey(rg => new{rg.IdRga});
            
            modelBuilder.Entity<Sexo>()
                .HasKey(s => new{s.IdSexo});

            modelBuilder.Entity<Situacoes>()
                .HasKey(st => new{st.IdSituacao});

            modelBuilder.Entity<Porte>()
                .HasKey(por => new {por.IdPorte});

            modelBuilder.Entity<Preferencias>
            (eb =>
                {
                    eb.HasNoKey();
                }
            );
         }
    }
}