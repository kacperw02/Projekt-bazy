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
        public DbSet<Zamowienie> Zamowienia { get; set; }
    }
}
