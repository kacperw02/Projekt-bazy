using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_bazy.Models
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }

        [Required(ErrorMessage = "Nazwa Sprzętu jest wymagana")]
        public string NazwaSprzetu { get; set; }

        [Required(ErrorMessage = "Data Zamówienia jest wymagana")]
        public DateTime DataZamowienia { get; set; }

        [Required(ErrorMessage = "IdZamawiajacego jest wymagane")]
        public int IdZamawiajacego { get; set; }

        [ForeignKey("IdZamawiajacego")]
        public Personel Zamawiajacy { get; set; }
    }
}
