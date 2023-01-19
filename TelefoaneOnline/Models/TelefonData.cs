//using TelefoaneOnline.Migrations;

namespace TelefoaneOnline.Models
{
    public class TelefonData
    {
        public IEnumerable<Telefon> Telefoane { get; set; }
        public IEnumerable<Memorie> Memorii { get; set; }
        public IEnumerable<MemorieInterna> MemoriiInterne { get; set; }
    }
}
