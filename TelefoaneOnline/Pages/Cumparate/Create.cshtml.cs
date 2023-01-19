using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Cumparate
{
    public class CreateModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public CreateModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            var telefonList = _context.Telefon
                 .Include(b => b.Memorie)
                 .Select(x => new { x.ID, Denumire = x.Denumire + " - " + x.Memorie.MemorieProdus + " " + x.Categorie.CategorieProdus });

            ViewData["TelefonID"] = new SelectList(telefonList, "ID", "Denumire");
            ViewData["UtilizatorID"] = new SelectList(_context.Utilizator, "ID", "NumeIntreg");

            return Page();
        }

        [BindProperty]
        public Cumparat Cumparat { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cumparat.Add(Cumparat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
