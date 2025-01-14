using System.ComponentModel.DataAnnotations;

namespace Projekt_bazy.Models
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienia { get; set; }
        public string NazwaSprzetu { get; set; }
        public DateTime DataZamowienia { get; set; }
        public int IdZamawiajacego { get; set; }
        public Personel Zamawiajacy { get; set; }
    }
}
