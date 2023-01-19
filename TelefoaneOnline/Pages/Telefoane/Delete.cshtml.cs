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
    public class DeleteModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DeleteModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Telefon Telefon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Telefon == null)
            {
                return NotFound();
            }

            var telefon = await _context.Telefon.FirstOrDefaultAsync(m => m.ID == id);

            if (telefon == null)
            {
                return NotFound();
            }
            else 
            {
                Telefon = telefon;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Telefon == null)
            {
                return NotFound();
            }
            var telefon = await _context.Telefon.FindAsync(id);

            if (telefon != null)
            {
                Telefon = telefon;
                _context.Telefon.Remove(Telefon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
