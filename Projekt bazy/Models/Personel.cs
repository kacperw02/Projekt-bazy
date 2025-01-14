using System.ComponentModel.DataAnnotations;

namespace Projekt_bazy.Models
{
    public class Personel
    {
        [Key]
        public int IdPersonelu { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Stopien { get; set; }
        public int? PrzynaleznoscDoMagazynu { get; set; }
        public Magazyn Magazyn { get; set; }

    }
}
