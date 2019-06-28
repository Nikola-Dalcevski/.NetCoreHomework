using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Models.Entities;
using Type = ToDo.Models.Entities.Type;

namespace ToDo.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbilder)
        {
            base.OnModelCreating(modelbilder);
            modelbilder.Entity<Task>().HasData(
              new Task { Id = 1, Title = "ProjectName", Type = Type.Work, Status = true, Priority = Priority.important, Description =" Some Discription" },
              new Task { Id = 2, Title = "PersonalName", Type = Type.Personal, Status = false, Priority = Priority.mediumImportant, Description =" Some Discription" },
              new Task { Id = 3, Title = "Running", Type = Type.Hobby, Status = true, Priority = Priority.notImportant, Description =" Some Discription" }
                );
        }
    }
}
