using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelefoaneOnline.Models;

namespace TelefoaneOnline.Data
{
    public class TelefoaneOnlineContext : DbContext
    {
        public TelefoaneOnlineContext (DbContextOptions<TelefoaneOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<TelefoaneOnline.Models.Telefon> Telefon { get; set; } = default!;

        public DbSet<TelefoaneOnline.Models.Categorie> Categorie { get; set; }

        public DbSet<TelefoaneOnline.Models.Culoare> Culoare { get; set; }

        public DbSet<TelefoaneOnline.Models.Cumparat> Cumparat { get; set; }

        public DbSet<TelefoaneOnline.Models.Memorie> Memorie { get; set; }

        public DbSet<TelefoaneOnline.Models.Utilizator> Utilizator { get; set; }
    }
}
