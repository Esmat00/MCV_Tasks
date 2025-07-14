using CategoryItemApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CategoryItemApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
