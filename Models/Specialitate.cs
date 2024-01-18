using System.ComponentModel.DataAnnotations;

namespace CameliaRasiga_ProiectMedii.Models
{
    public class Specialitate
    {
        public int ID { get; set; }
        [Display(Name = "Denumire Specialitate")]
        public string Denumire { get; set; }

        public ICollection<Medic>? Medici { get; set; }

        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
