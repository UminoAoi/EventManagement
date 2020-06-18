using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProjektImplementacja.Model
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MASProjekt;Integrated Security=True;Pooling=False");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Uzytkownik> Uzytkownicy { get; set; }
        public DbSet<Organizator> Organizatorzy { get; set; }
        public DbSet<Uczestnik> Uczestnicy { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Wystawca> Wystawcy { get; set; }
        public DbSet<Bilet> Bilety { get; set; }
        public DbSet<Event> Eventy { get; set; }
        public DbSet<MiejsceEventu> MiejscaEventu { get; set; }
        public DbSet<Atrakcja> Atrakcje { get; set; }
        public DbSet<Konkurs> Konkursy { get; set; }
        public DbSet<Panel> Panele { get; set; }
        public DbSet<Nagroda> Nagrody { get; set; }
        public DbSet<PanelKonkursowy> PaneleKonkursowe { get; set; }

        public DbSet<Atrakcja_Uczestnik> Atrakcja_Uczestnicy  { get; set; }
        public DbSet<Event_Pracownik> Event_Pracownicy { get; set; }
        public DbSet<Event_Wystawca> Event_Wystawcy { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-one relationships

            modelBuilder.Entity<Organizator>().HasOne(b => b.Uzytkownik).WithOne(i => i.Organizator).HasForeignKey<Uzytkownik>(b => b.IdOrganizator).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pracownik>().HasOne(b => b.Uzytkownik).WithOne(i => i.Pracownik).HasForeignKey<Uzytkownik>(b => b.IdPracownik).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Uczestnik>().HasOne(b => b.Uzytkownik).WithOne(i => i.Uczestnik).HasForeignKey<Uzytkownik>(b => b.IdUczestnik).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Konkurs>()
                .HasOne(b => b.PanelKonkursowy)
                .WithOne(i => i.Konkurs)
                .HasForeignKey<PanelKonkursowy>(b => b.IdKonkurs).OnDelete(DeleteBehavior.Restrict);
            //restrict przy jednym połączeniu w wielodziedziczeniu, żeby nie próbowało usunąć dwa razy czegoś

            modelBuilder.Entity<Nagroda>()
                .HasOne(b => b.Konkurs)
                .WithOne(i => i.Nagroda)
                .HasForeignKey<Konkurs>(b => b.IdNagroda).OnDelete(DeleteBehavior.Cascade);

            //many-to-many
            modelBuilder.Entity<Event_Wystawca>()
                .HasKey(t => new { t.IdWystawca, t.IdEvent });

            modelBuilder.Entity<Event_Wystawca>()
                .HasOne(pt => pt.Wystawca)
                .WithMany(p => p.Eventy)
                .HasForeignKey(pt => pt.IdWystawca);

            modelBuilder.Entity<Event_Wystawca>()
                .HasOne(pt => pt.Event)
                .WithMany(t => t.Wystawcy)
                .HasForeignKey(pt => pt.IdEvent);


            modelBuilder.Entity<Event_Pracownik>()
                .HasKey(t => new { t.IdEvent, t.IdPracownik });

            modelBuilder.Entity<Event_Pracownik>()
                .HasOne(pt => pt.Pracownik)
                .WithMany(p => p.Eventy)
                .HasForeignKey(pt => pt.IdPracownik);

            modelBuilder.Entity<Event_Pracownik>()
                .HasOne(pt => pt.Event)
                .WithMany(t => t.Pracownicy)
                .HasForeignKey(pt => pt.IdEvent);


            modelBuilder.Entity<Atrakcja_Uczestnik>()
                .HasKey(t => new { t.IdAtrakcja, t.IdUczestnik });

            modelBuilder.Entity<Atrakcja_Uczestnik>()
                .HasOne(pt => pt.Uczestnik)
                .WithMany(p => p.Atrakcje)
                .HasForeignKey(pt => pt.IdUczestnik);

            modelBuilder.Entity<Atrakcja_Uczestnik>()
                .HasOne(pt => pt.Atrakcja)
                .WithMany(t => t.Uczestnicy)
                .HasForeignKey(pt => pt.IdAtrakcja);

            //one-to-many
            modelBuilder.Entity<Event>()
              .HasOne(pt => pt.Organizator)
              .WithMany(t => t.Eventy).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Wystawca>()
              .HasOne(pt => pt.Organizator)
              .WithMany(t => t.Wystawcy).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
