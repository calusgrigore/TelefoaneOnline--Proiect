using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Culori
{
    public class DeleteModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DeleteModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Culoare Culoare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Culoare == null)
            {
                return NotFound();
            }

            var culoare = await _context.Culoare.FirstOrDefaultAsync(m => m.ID == id);

            if (culoare == null)
            {
                return NotFound();
            }
            else 
            {
                Culoare = culoare;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Culoare == null)
            {
                return NotFound();
            }
            var culoare = await _context.Culoare.FindAsync(id);

            if (culoare != null)
            {
                Culoare = culoare;
                _context.Culoare.Remove(Culoare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
