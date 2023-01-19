using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;
using TelefoaneOnline.Models.ViewModels;

namespace TelefoaneOnline.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public IndexModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get; set; } = default!;

        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int TelefonID { get; set; }
        public async Task OnGetAsync(int? id, int? telefonID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
            .Include(i => i.Telefoane)
            .ThenInclude(c => c.Memorie )
            .OrderBy(i => i.CategorieProdus)
            .ToListAsync();
            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieData.Categorii
                .Where(i => i.ID == id.Value).Single();
                CategorieData.Telefoane = categorie.Telefoane;
            }

        }
    }
}
