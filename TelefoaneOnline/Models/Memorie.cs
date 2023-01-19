using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TelefoaneOnline.Models
{
    public class Memorie
    {
        public int ID { get; set; }
        public string MemorieProdus { get; set; }
        public ICollection<MemorieInterna>? MemoriiInterne { get; set; }
    }
}
