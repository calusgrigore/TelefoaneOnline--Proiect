using System.Security.Policy;

namespace TelefoaneOnline.Models.ViewModels
{
    public class CategorieIndexData
    {
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<Telefon> Telefoane { get; set; }
    }
}
