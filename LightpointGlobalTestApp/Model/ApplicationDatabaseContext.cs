using System;
using LightpointGlobalTestApp.Model.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace LightpointGlobalTestApp.Model
{
    public class ApplicationDatabaseContext: DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.Items)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
