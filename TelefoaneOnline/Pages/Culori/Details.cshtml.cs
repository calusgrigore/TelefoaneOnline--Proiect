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
    public class DetailsModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DetailsModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

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
    }
}
