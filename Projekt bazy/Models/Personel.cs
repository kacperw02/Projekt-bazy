using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_bazy.Models
{
    public class Personel
    {
        [Key]
        public int IdPersonelu { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Stopień jest wymagany")]
        public string Stopien { get; set; }

        [Required(ErrorMessage = "Przynależność jest wymagana")]
        public int Przynaleznosc { get; set; }

        public Magazyn? Magazyn { get; set; }

        public ICollection<Zamowienia>? Zamowienia { get; set; }
    }
}
