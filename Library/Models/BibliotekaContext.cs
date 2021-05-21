using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Library.Models
{
    public partial class BibliotekaContext : DbContext
    {
        public BibliotekaContext()
        {
        }

        public BibliotekaContext(DbContextOptions<BibliotekaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autorzy { get; set; }
        public virtual DbSet<Gatunek> Gatunki { get; set; }
        public virtual DbSet<Klient> Klienci { get; set; }
        public virtual DbSet<Książka> Książki { get; set; }
        public virtual DbSet<Pracownik> Pracownicy { get; set; }
        public virtual DbSet<Wypożyczenie> Wypożyczenia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Biblioteka;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autorzy");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImięAutora)
                    .HasMaxLength(50)
                    .HasColumnName("Imię_Autora");

                entity.Property(e => e.NazwiskoAutora)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nazwisko_Autora");
            });

            modelBuilder.Entity<Gatunek>(entity =>
            {
                entity.ToTable("Gatunki");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NazwaGatunku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nazwa_Gatunku");
            });

            modelBuilder.Entity<Klient>(entity =>
            {
                entity.ToTable("Klienci");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdresEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Adres_email");

                entity.Property(e => e.AdresZamieszkania)
                    .IsRequired()
                    .HasColumnName("Adres_zamieszkania");

                entity.Property(e => e.DataRejestracji)
                    .HasColumnType("date")
                    .HasColumnName("Data_rejestracji");

                entity.Property(e => e.ImięKlienta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Imię_Klienta");

                entity.Property(e => e.NazwiskoKlienta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nazwisko_Klienta");

                entity.Property(e => e.NumerTelefonu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Numer_telefonu");

                entity.Property(e => e.Pesel)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("PESEL")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Książka>(entity =>
            {
                entity.ToTable("Książki");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idautor).HasColumnName("IDAutor");

                entity.Property(e => e.Idgatunek).HasColumnName("IDGatunek");

                entity.Property(e => e.Tytuł)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdautorNavigation)
                    .WithMany(p => p.Książki)
                    .HasForeignKey(d => d.Idautor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Książki_Autorzy");

                entity.HasOne(d => d.IdgatunekNavigation)
                    .WithMany(p => p.Książki)
                    .HasForeignKey(d => d.Idgatunek)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Książki_Gatunki");
            });

            modelBuilder.Entity<Pracownik>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Pracownicy");

                entity.Property(e => e.Hasło)
                    .IsRequired()
                    .HasMaxLength(63)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ImięPracownika)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Imię_Pracownika");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NazwiskoPracownika)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Nazwisko_Pracownika");
            });

            modelBuilder.Entity<Wypożyczenie>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataWypożyczenia)
                    .HasColumnType("date")
                    .HasColumnName("Data_wypożyczenia");

                entity.Property(e => e.DataZwrotu)
                    .HasColumnType("date")
                    .HasColumnName("Data_zwrotu");

                entity.Property(e => e.Idklient).HasColumnName("IDKlient");

                entity.Property(e => e.Idksiążka).HasColumnName("IDKsiążka");

                entity.HasOne(d => d.IdklientNavigation)
                    .WithMany(p => p.Wypożyczenia)
                    .HasForeignKey(d => d.Idklient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wypożyczenia_Klienci");

                entity.HasOne(d => d.IdksiążkaNavigation)
                    .WithMany(p => p.Wypożyczenia)
                    .HasForeignKey(d => d.Idksiążka)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wypożyczenia_Książki");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
