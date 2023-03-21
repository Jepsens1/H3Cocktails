using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using H3Cocktails.Models;
using System;

namespace H3Cocktails
{
    public class CocktailContext : DbContext
    {
        public CocktailContext(DbContextOptions<CocktailContext> option) : base(option)
        {

        }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Delete from both Drink table and Ingredient table
            modelBuilder.Entity<Drink>()
                .HasMany(a => a.Ingrediens)
                .WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
