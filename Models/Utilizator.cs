using System.ComponentModel.DataAnnotations;

namespace CameliaRasiga_ProiectMedii.Models
{
    public class Utilizator
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie sa inceapa cu majuscula (ex. Rasiga")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Numele trebuie sa aiba un numar de caractere cuprins intre 3-30")]
        public string? Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula (ex. Camelia sau Camelia Ana")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Prenumele trebuie sa aiba un numar de caractere cuprins intre 3-30")]
        public string? Prenume { get; set; }
        [StringLength(70, ErrorMessage ="Adresa nu poate fi mai lunga de 70 de caractere!")]
        public string? Adresa { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^([0]{1})([0-9]{3})[-. ]([0-9]{3})[-. ]([0-9]{3})$",
            ErrorMessage = "Telefonul trebuie sa inceapa cu cifra 0 si sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
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
