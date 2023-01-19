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

namespace TelefoaneOnline.Pages.Memorii
{
    public class EditModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public EditModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Memorie Memorie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Memorie == null)
            {
                return NotFound();
            }

            var memorie =  await _context.Memorie.FirstOrDefaultAsync(m => m.ID == id);
            if (memorie == null)
            {
                return NotFound();
            }
            Memorie = memorie;
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

            _context.Attach(Memorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemorieExists(Memorie.ID))
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

        private bool MemorieExists(int id)
        {
          return _context.Memorie.Any(e => e.ID == id);
        }
    }
}
