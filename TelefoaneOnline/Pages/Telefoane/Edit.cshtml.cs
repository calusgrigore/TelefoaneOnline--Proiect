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

namespace TelefoaneOnline.Pages.Telefoane
{
    public class EditModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public EditModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Telefon Telefon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Telefon == null)
            {
                return NotFound();
            }

            var telefon =  await _context.Telefon.FirstOrDefaultAsync(m => m.ID == id);
            if (telefon == null)
            {
                return NotFound();
            }
            Telefon = telefon;
           ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "CategorieProdus");
           ViewData["MemorieID"] = new SelectList(_context.Set<Memorie>(), "ID", "MemorieProdus");
           ViewData["CuloareID"] = new SelectList(_context.Set<Culoare>(), "ID", "CuloareProdus");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Telefon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonExists(Telefon.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TelefonExists(int id)
        {
          return _context.Telefon.Any(e => e.ID == id);
        }
    }
}
