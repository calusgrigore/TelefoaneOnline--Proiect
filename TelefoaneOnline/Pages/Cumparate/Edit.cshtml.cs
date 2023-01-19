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
    public class EditModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public EditModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cumparat Cumparat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparat == null)
            {
                return NotFound();
            }

            var cumparat =  await _context.Cumparat.FirstOrDefaultAsync(m => m.ID == id);
            if (cumparat == null)
            {
                return NotFound();
            }
            Cumparat = cumparat;
           ViewData["TelefonID"] = new SelectList(_context.Telefon, "ID", "ID");
           ViewData["UtilizatorID"] = new SelectList(_context.Set<Utilizator>(), "ID", "ID");
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

            _context.Attach(Cumparat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CumparatExists(Cumparat.ID))
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

        private bool CumparatExists(int id)
        {
          return _context.Cumparat.Any(e => e.ID == id);
        }
    }
}
