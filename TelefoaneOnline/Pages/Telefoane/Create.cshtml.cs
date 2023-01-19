using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Telefoane
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
        ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "CategorieProdus");
        ViewData["MemorieID"] = new SelectList(_context.Set<Memorie>(), "ID", "MemorieProdus");
        ViewData["CuloareID"] = new SelectList(_context.Set<Culoare>(), "ID", "CuloareProdus");
            return Page();
        }

        [BindProperty]
        public Telefon Telefon { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Telefon.Add(Telefon);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
