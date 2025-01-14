using System.ComponentModel.DataAnnotations;

namespace Projekt_bazy.Models
{
    public class Sprzet
    {
        [Key]
        public int IdSprzetu { get; set; }
        public string NazwaSprzetu { get; set; }
        public DateTime DataWstawienia { get; set; }
        public int? MagazynId { get; set; }
        public Magazyn Magazyn { get; set; }
    }
}
