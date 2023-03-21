using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using H3Cocktails.Models;

namespace H3Cocktails
{
    public class CocktailContext : DbContext
    {
        public CocktailContext(DbContextOptions<CocktailContext> option) : base(option)
        {

        }

        public DbSet<Drink> Drinks { get; set; }
    }
}
