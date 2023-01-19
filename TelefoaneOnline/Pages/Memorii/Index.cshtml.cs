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
    public class IndexModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public IndexModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        public IList<Memorie> Memorie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Memorie != null)
            {
                Memorie = await _context.Memorie.ToListAsync();
            }
        }
    }
}
