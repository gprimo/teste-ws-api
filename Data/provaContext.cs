using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoticiasAPI.Models;

namespace NoticiasAPI.Data
{
    public class provaContext : DbContext
    {
        public provaContext (DbContextOptions<provaContext> options)
            : base(options)
        {
        }

        public DbSet<NoticiasAPI.Models.Noticias> Noticias { get; set; }

        public DbSet<Login> Login { get; set; }
    }
}
