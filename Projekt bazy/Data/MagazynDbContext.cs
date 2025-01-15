using Microsoft.EntityFrameworkCore;
using Projekt_bazy.Models;

namespace Projekt_bazy.Data
{
    public class MagazynDbContext : DbContext
    {
        public MagazynDbContext(DbContextOptions<MagazynDbContext> options)
            : base(options)
        {
        }

        public DbSet<Magazyn> Magazyny { get; set; }
        public DbSet<Sprzet> Sprzety { get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<Zamowienia> Zamowienia { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacja Magazyn -> Sprzet
            modelBuilder.Entity<Sprzet>()
                .HasOne(s => s.Magazyn)
                .WithMany(m => m.Sprzety)
                .HasForeignKey(s => s.MagazynId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja Magazyn -> Personel
            modelBuilder.Entity<Personel>()
                .HasOne(p => p.Magazyn)
                .WithMany(m => m.Personel)
                .HasForeignKey(p => p.Przynaleznosc)
                .OnDelete(DeleteBehavior.Cascade);


            // Relacja Magazyn -> Zamowienia
            modelBuilder.Entity<Zamowienia>()
                .HasOne(z => z.Magazyn)
                .WithMany()
                .HasForeignKey(z => z.MagazynId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacja Personel -> Zamowienia
            modelBuilder.Entity<Zamowienia>()
                .HasOne(z => z.Zamawiajacy)
                .WithMany(p => p.Zamowienia)
                .HasForeignKey(z => z.ZamawiajacyId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
