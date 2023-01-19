using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Cumparate
{
    public class DeleteModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DeleteModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cumparat Cumparat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparat == null)
            {
                return NotFound();
            }

            var cumparat = await _context.Cumparat.FirstOrDefaultAsync(m => m.ID == id);

            if (cumparat == null)
            {
                return NotFound();
            }
            else 
            {
                Cumparat = cumparat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cumparat == null)
            {
                return NotFound();
            }
            var cumparat = await _context.Cumparat.FindAsync(id);

            if (cumparat != null)
            {
                Cumparat = cumparat;
                _context.Cumparat.Remove(Cumparat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
