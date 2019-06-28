using Microsoft.EntityFrameworkCore;
using PizzaHut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaHut
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzaTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbilder)
        {
            base.OnModelCreating(modelbilder);
            modelbilder.Entity<User>().HasData(
              new User { ID = 1, Name = "Nikola", City = "Skopje", Address = "main street", Email = "nikola@gmail", Phone = "2222" }
            
                );
        }
        
    }
}
