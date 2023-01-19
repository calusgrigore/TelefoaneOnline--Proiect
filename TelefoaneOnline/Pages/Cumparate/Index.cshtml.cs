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
    public class IndexModel : PageModel
    {
        private readonly TelefoaneOnline.Data.TelefoaneOnlineContext _context;

        public IndexModel(TelefoaneOnline.Data.TelefoaneOnlineContext context)
        {
            _context = context;
        }

        public IList<Cumparat> Cumparat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cumparat != null)
            {
                Cumparat = await _context.Cumparat
                .Include(c => c.Telefon)
                .ThenInclude(b => b.Memorie)
                .Include(c => c.Utilizator).ToListAsync();
            }
        }
    }
}
