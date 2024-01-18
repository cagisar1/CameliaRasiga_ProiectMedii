using System.ComponentModel.DataAnnotations;

namespace CameliaRasiga_ProiectMedii.Models
{
    public class Utilizator
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }
        [Display(Name = "Full Name")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<UtilizatorServiciu> UtilizatorServicii { get; set; }
    }
}
