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
    public class DetailsModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public DetailsModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

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
    }
}
