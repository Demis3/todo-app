using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoListLibrary.Models;

namespace ToDoListLibrary.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ToDoTask> toDoTasks { get; set; }
        public DbSet<ToDoList> toDoLists { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=todoapp;Trusted_Connection=True;");
        }
    }
}
