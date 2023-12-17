using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clase4.Models;

namespace Clase4.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext (DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public DbSet<Clase4.Models.Menu> Menu { get; set; } = default!;
        public DbSet<Clase4.Models.Restaurant> Restaurant { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)//Config de la relacion con el Restaurante de muchos a muchos
        {
            modelBuilder.Entity<Menu>().HasMany(x => x.Restaurants).WithMany(x =>x.Menus).UsingEntity("MenuRestaurant");
        }

        
    }
}
