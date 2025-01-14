using System.ComponentModel.DataAnnotations;

namespace Projekt_bazy.Models
{
    public class Magazyn
    {
        [Key]
        public int IdMagazynu { get; set; }
        public string Funkcjonalnosc { get; set; }
        public string Lokalizacja { get; set; }
        public ICollection<Sprzet> Sprzety { get; set; }
        public ICollection<Personel> Personel { get; set; }
    }
}
