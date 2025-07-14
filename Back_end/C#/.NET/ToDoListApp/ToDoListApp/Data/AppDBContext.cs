using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
