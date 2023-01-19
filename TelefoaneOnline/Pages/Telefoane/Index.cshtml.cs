using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Telefoane
{
    public class IndexModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public IndexModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        public IList<Telefon> Telefon { get; set; } = default!;

        public TelefonData TelefonD { get; set; }
        public int TelefonID { get; set; }
        public int MemorieID { get; set; }

        public string DenumireSort { get; set; }
        public string MemorieSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? tipID, string sortOrder, string searchString)
        {
            TelefonD = new TelefonData();

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "denumire_desc" : "";
            MemorieSort = String.IsNullOrEmpty(sortOrder) ? "memorie_desc" : "";

            CurrentFilter = searchString;

            TelefonD.Telefoane = await _context.Telefon
                    .Include(b => b.Categorie)
                    .Include(b => b.Memorie)
                    .Include(b => b.Culoare)
                    .AsNoTracking()
                    .OrderBy(b => b.Denumire)
                    .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                TelefonD.Telefoane = TelefonD.Telefoane.Where(s => s.Memorie.MemorieProdus.Contains(searchString)

               || s.Memorie.MemorieProdus.Contains(searchString)
               || s.Denumire.Contains(searchString));
            }



            if (id != null)
            {
                TelefonID = id.Value;
                Telefon telefon = TelefonD.Telefoane
                .Where(i => i.ID == id.Value).Single();
               
            }
            switch (sortOrder)
            {
                case "denumire_desc":
                    TelefonD.Telefoane = TelefonD.Telefoane.OrderByDescending(s =>
                   s.Denumire);
                    break;
                case "memorie_desc":
                    TelefonD.Telefoane = TelefonD.Telefoane.OrderByDescending(s =>
                   s.Memorie.MemorieProdus);
                    break;
            }
        }
    }
}