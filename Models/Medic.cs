using System.ComponentModel.DataAnnotations;

namespace CameliaRasiga_ProiectMedii.Models
{
    public class Medic
    {
        public int ID { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        [Display(Name = "Specialitate")]
        public int? SpecialitateID { get; set; }
        public Specialitate? Specialitate { get; set; }

        [Display(Name = "Grad Profesional")]
        public string Grad { get; set; }

        public int? LocatieID { get; set; }
        public Locatie? Locatie { get; set; }

        public ICollection<Serviciu>? Servicii { get; set; }

        [Display(Name = "Medic")]
        public string NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
    }
}
