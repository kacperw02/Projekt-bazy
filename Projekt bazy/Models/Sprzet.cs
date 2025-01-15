using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_bazy.Models
{
    public class Sprzet
    {
        [Key]
        public int IdSprzetu { get; set; }

        [Required(ErrorMessage = "Nazwa Sprzętu jest wymagana")]
        public string NazwaSprzetu { get; set; }

        [Required(ErrorMessage = "Data Wstawienia jest wymagana")]
        public DateTime DataWstawienia { get; set; }

        [Required(ErrorMessage = "MagazynId jest wymagane")]
        public int? MagazynId { get; set; }

        [ForeignKey("MagazynId")]
        public Magazyn Magazyn { get; set; }
    }
}
