using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Memorii
{
    public class DeleteModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DeleteModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Memorie Memorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Memorie == null)
            {
                return NotFound();
            }

            var memorie = await _context.Memorie.FirstOrDefaultAsync(m => m.ID == id);

            if (memorie == null)
            {
                return NotFound();
            }
            else 
            {
                Memorie = memorie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Memorie == null)
            {
                return NotFound();
            }
            var memorie = await _context.Memorie.FindAsync(id);

            if (memorie != null)
            {
                Memorie = memorie;
                _context.Memorie.Remove(Memorie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
