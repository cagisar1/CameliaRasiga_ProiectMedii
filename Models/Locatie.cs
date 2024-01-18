using System.ComponentModel.DataAnnotations;

namespace CameliaRasiga_ProiectMedii.Models
{
    public class Locatie
    {
        public int ID { get; set; }
        [Display(Name = "Nume Locatie")]

        public string Nume { get; set; }

        public string Adresa { get; set; }

        public string Localitate { get; set; }

        public ICollection<Medic>? Medici { get; set; } //navigation property
    }
}
