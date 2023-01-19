//using TelefoaneOnline.Migrations;

namespace TelefoaneOnline.Models
{
    public class MemorieInterna
    {
        public int ID { get; set; }
        public int TelefonID { get; set; }
        public Telefon Telefon { get; set; }
        public int MemorieID { get; set; }
        public Memorie Memorie { get; set; }
    }
}
