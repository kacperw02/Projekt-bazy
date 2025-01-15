using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_bazy.Models
{
    public class Magazyn
    {
        [Key]
        public int IdMagazynu { get; set; }

        [Required(ErrorMessage = "Funkcjonalność jest wymagana")]
        public string Funkcjonalnosc { get; set; }

        [Required(ErrorMessage = "Lokalizacja jest wymagana")]
        public string Lokalizacja { get; set; }

        public ICollection<Sprzet>? Sprzety { get; set; }
        public ICollection<Personel>? Personel { get; set; }
        public ICollection<Zamowienia>? Zamowienia { get; set; }
    }
}
