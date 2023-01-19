using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Data;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Pages.Utilizatori
{
    public class DetailsModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DetailsModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

      public Utilizator Utilizator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Utilizator == null)
            {
                return NotFound();
            }

            var utilizator = await _context.Utilizator.FirstOrDefaultAsync(m => m.ID == id);
            if (utilizator == null)
            {
                return NotFound();
            }
            else 
            {
                Utilizator = utilizator;
            }
            return Page();
        }
    }
}
