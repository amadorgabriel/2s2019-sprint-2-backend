using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Optus.WebApi.Domains
{
    public partial class OptusContext : DbContext
    {
        public OptusContext()
        {
        }

        public OptusContext(DbContextOptions<OptusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artistas> Artistas { get; set; }
        public virtual DbSet<Estilos> Estilos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                 optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_Optus;User Id=sa;Pwd=132");

                //Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=T_SStop;Data Source=DESKTOP-JBDLFFG\MSSQLSERVER01
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-JBDLFFG\\MSSQLSERVER01;Initial Catalog=T_Optus;Integrated Security=SSPI;");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artistas>(entity =>
            {
                entity.HasKey(e => e.IdArtista);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Artistas__7D8FE3B29A5ECDA8")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstiloNavigation)
                    .WithMany(p => p.Artistas)
                    .HasForeignKey(d => d.IdEstilo)
                    .HasConstraintName("FK__Artistas__IdEsti__4D94879B");
            });

            modelBuilder.Entity<Estilos>(entity =>
            {
                entity.HasKey(e => e.IdEstilo);

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Estilos__7D8FE3B2BA6A0421")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D105348B3CE059")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Permissao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
