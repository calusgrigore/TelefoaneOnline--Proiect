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
    public class DetailsModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DetailsModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

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
    }
}
