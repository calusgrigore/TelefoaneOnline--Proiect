using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace TelefoaneOnline.Models
{
    public class Cumparat
    {
        public int ID { get; set; }
        public int? UtilizatorID { get; set; }
        public Utilizator? Utilizator { get; set; }
        public int? TelefonID { get; set; }
        public Telefon? Telefon { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataAchizitie { get; set; }
    }
}
