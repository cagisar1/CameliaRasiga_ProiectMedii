using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace CameliaRasiga_ProiectMedii.Models
{
    public class UtilizatorServiciu
    {
        public int ID { get; set; }
        public int? UtilizatorID { get; set; }
        public Utilizator? Utilizator { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Data")]
        public DateTime ReturnDate { get; set; }
    }
}
