using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace mvc.Models
{
    public partial class darbasContext : DbContext
    {
        public darbasContext()
        {
        }

        public darbasContext(DbContextOptions<darbasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apmokejima> Apmokejimas { get; set; }
        public virtual DbSet<Isimintum> Isiminta { get; set; }
        public virtual DbSet<Kategorija> Kategorijas { get; set; }
        public virtual DbSet<Komentara> Komentaras { get; set; }
        public virtual DbSet<Skelbima> Skelbimas { get; set; }
        public virtual DbSet<Vartotoja> Vartotojas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost; port=3306; user=root; SslMode=none;database=darbas");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apmokejima>(entity =>
            {
                entity.ToTable("apmokejimas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Isimintum>(entity =>
            {
                entity.ToTable("isiminta");

                entity.HasIndex(e => e.FkSkelbimasid, "fk_Skelbimasid");

                entity.HasIndex(e => e.FkVartotojasid, "fk_Vartotojasid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FkSkelbimasid)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Skelbimasid");

                entity.Property(e => e.FkVartotojasid)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Vartotojasid");

                entity.HasOne(d => d.FkSkelbimas)
                    .WithMany(p => p.Isiminta)
                    .HasForeignKey(d => d.FkSkelbimasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("isiminta_ibfk_1");

                entity.HasOne(d => d.FkVartotojas)
                    .WithMany(p => p.Isiminta)
                    .HasForeignKey(d => d.FkVartotojasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("isiminta_ibfk_2");
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.ToTable("kategorija");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pavadinimas");
            });

            modelBuilder.Entity<Komentara>(entity =>
            {
                entity.ToTable("komentaras");

                entity.HasIndex(e => e.FkSkelbimasid, "fk_Skelbimasid");

                entity.HasIndex(e => e.FkVartotojasid, "fk_Vartotojasid");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.FkSkelbimasid)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Skelbimasid");

                entity.Property(e => e.FkVartotojasid)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Vartotojasid");

                entity.Property(e => e.Komentaras)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("komentaras");

                entity.HasOne(d => d.FkSkelbimas)
                    .WithMany(p => p.Komentaras)
                    .HasForeignKey(d => d.FkSkelbimasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("komentaras_ibfk_2");

                entity.HasOne(d => d.FkVartotojas)
                    .WithMany(p => p.Komentaras)
                    .HasForeignKey(d => d.FkVartotojasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("komentaras_ibfk_1");
            });

            modelBuilder.Entity<Skelbima>(entity =>
            {
                entity.ToTable("skelbimas");

                entity.HasIndex(e => e.FkKategorijaid, "fk_Kategorijaid");

                entity.HasIndex(e => e.FkVartotojasid, "fk_Vartotojasid")
                    .IsUnique();

                entity.HasIndex(e => e.MokejimoBudas, "mokejimo_budas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Aprasymas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("aprasymas");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.FkKategorijaid)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Kategorijaid");

                entity.Property(e => e.FkVartotojasid)
                    .HasColumnType("int(11)")
                    .HasColumnName("fk_Vartotojasid");

                entity.Property(e => e.MokejimoBudas)
                    .HasColumnType("int(11)")
                    .HasColumnName("mokejimo_budas");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pavadinimas");

                entity.Property(e => e.Uzmokestis)
                    .HasColumnType("decimal(16,2)")
                    .HasColumnName("uzmokestis");

                entity.HasOne(d => d.FkKategorija)
                    .WithMany(p => p.Skelbimas)
                    .HasForeignKey(d => d.FkKategorijaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skelbimas_ibfk_3");

                entity.HasOne(d => d.FkVartotojas)
                    .WithOne(p => p.Skelbima)
                    .HasForeignKey<Skelbima>(d => d.FkVartotojasid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skelbimas_ibfk_2");

                entity.HasOne(d => d.MokejimoBudasNavigation)
                    .WithMany(p => p.Skelbimas)
                    .HasForeignKey(d => d.MokejimoBudas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skelbimas_ibfk_1");
            });

            modelBuilder.Entity<Vartotoja>(entity =>
            {
                entity.ToTable("vartotojas");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EPastas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("e_pastas");

                entity.Property(e => e.Miestas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("miestas");

                entity.Property(e => e.Slaptazodis)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("slaptazodis");

                entity.Property(e => e.Telefonas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("telefonas");

                entity.Property(e => e.Vardas)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("vardas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
