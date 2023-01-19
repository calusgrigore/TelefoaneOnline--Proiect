using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TelefoaneOnline.Models
{
    public class Utilizator
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Introduceti numele cu majuscula ex. Pop")]
        [StringLength(20, MinimumLength = 7)]
        public string? Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage ="Introduceti prenumele cu majuscula ex. Ion")]
        [StringLength(20, MinimumLength = 7)]
        public string? Prenume { get; set; }
        [StringLength(50)]
        public string? Adresa { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0700-111-222' sau '0700.111.222' sau '0700 111 222'")]
        public string? Telefon { get; set; }
        [Display(Name = "Nume Intreg")]
        public string? NumeIntreg 
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Cumparat>? Cumparate { get; set; }
    }
}


