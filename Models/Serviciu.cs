using System.ComponentModel.DataAnnotations;

namespace CameliaRasiga_ProiectMedii.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        public string Denumire { get; set; }

        [Display(Name = "Specialitate")]
        public int? SpecialitateID { get; set; }
        public Specialitate? Specialitate { get; set; }

        public decimal Pret { get; set; }
        public int? MedicID { get; set; }
        public Medic? Medic { get; set; }

        ICollection<UtilizatorServiciu>? UtilizatorServicii { get; set; }
    }
}
