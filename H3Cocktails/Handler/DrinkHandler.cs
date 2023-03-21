using H3Cocktails.Models;
using Microsoft.EntityFrameworkCore;

namespace H3Cocktails.Handler
{
    public class DrinkHandler
    {
        private readonly CocktailContext _context;

        public DrinkHandler(CocktailContext context)
        {
            _context = context;
        }

        public async Task<List<Drink>> GetAllDrinks()
        {
            if (_context.Drinks == null)
            {
                return null;
            }
            return await _context.Drinks.Include(f => f.Ingrediens).ToListAsync();
        }
        public async Task<Drink> GetDrink(string name)
        {
            var drink = _context.Drinks.Include(d => d.Ingrediens).Where(d => d.Name== name).FirstOrDefault();
            if(drink == null)
            {
                return null;
            }
            return drink;
        }
        public async Task<string> AddDrink(Drink d)
        {
            await _context.Drinks.AddAsync(d);
            await _context.SaveChangesAsync();

            var drink = await _context.Drinks.FindAsync(d.Name);
            if (drink == null)
            {
                return null;
            }
            return $"Added {drink.Name}";
        }
        public async Task<string> RemoveDrink(string name)
        {
            var drink = await _context.Drinks.FindAsync(name);
            if(drink == null)
            {
                return null;
            }
            return $"Removed {name}";
        }
        
      
    }
}
