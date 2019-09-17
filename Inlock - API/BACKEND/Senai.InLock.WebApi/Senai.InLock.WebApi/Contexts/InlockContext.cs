using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.InLock.WebApi.Domains
{
    public partial class InlockContext : DbContext
    {
        public InlockContext()
        {
        }

        public InlockContext(DbContextOptions<InlockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudios> Estudios { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=T_Inlock;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudios>(entity =>
            {
                entity.HasKey(e => e.EstudioId);

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.NomeEstudio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PaisOrigem)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Estudios)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Estudios__Usuari__4CA06362");
            });

            modelBuilder.Entity<Jogos>(entity =>
            {
                entity.HasKey(e => e.JogoId);

                entity.Property(e => e.DataLancamento).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeJogo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.HasOne(d => d.Estudio)
                    .WithMany(p => p.Jogos)
                    .HasForeignKey(d => d.EstudioId)
                    .HasConstraintName("FK__Jogos__EstudioId__4F7CD00D");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534DEB844CC")
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
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
