using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_bazy.Models
{
    public class Zamowienia
    {
        [Key]
        public int IdZamowienia { get; set; }

        [Required(ErrorMessage = "Nazwa Sprzętu jest wymagana")]
        public string NazwaSprzetu { get; set; }

        [Required(ErrorMessage = "Data Zamówienia jest wymagana")]
        public DateTime DataZamowienia { get; set; }

        [Required(ErrorMessage = "Zamawiajacy jest wymagane")]
        public int ZamawiajacyId { get; set; }
        public Personel? Zamawiajacy { get; set; }

        [Required(ErrorMessage = "Magazyn jest wymagany")]
        public int MagazynId { get; set; }

        public Magazyn? Magazyn { get; set; }
    }
}
