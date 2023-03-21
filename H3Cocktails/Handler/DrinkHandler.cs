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
        /// <summary>
        /// Provides a List<Drink> 
        /// </summary>
        /// <returns>Returns all Drinks as list</returns>
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
            //Gets drink from name
            //Include Ingrediens otherwise it is null
            var drink = _context.Drinks.Include(d => d.Ingrediens).Where(d => d.Name== name).FirstOrDefault();
            if(drink == null)
            {
                return null;
            }
            return drink;
        }
        /// <summary>
        /// Adds a new Drink to Database
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public async Task<string> AddDrink(Drink d)
        {
            //Adds the new Drink
            await _context.Drinks.AddAsync(d);
            await _context.SaveChangesAsync();

            //Finds the newly added drink
            var drink = await _context.Drinks.Where(n => n.Name == d.Name).FirstOrDefaultAsync();
            if (drink == null)
            {
                return null;
            }
            return $"Added {drink.Name}";
        }
        /// <summary>
        /// Removes Drink from database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<string> RemoveDrink(string name)
        {
            //Finds drink via Name
            var drink = await _context.Drinks.Include(f => f.Ingrediens).Where(d => d.Name == name).FirstOrDefaultAsync();
            if(drink == null)
            {
                return null;
            }
            _context.Drinks.Remove(drink);
            await _context.SaveChangesAsync();
            return $"Removed {name}";
        }
        /// <summary>
        /// Updates a Drink in a database
        /// </summary>
        /// <param name="name"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public async Task<string> UpdateDrink(string name,Drink d)
        {
            //Finds drink via name
            var drink = await _context.Drinks.Include(f => f.Ingrediens).Where(d => d.Name == name).FirstOrDefaultAsync();
            if(drink == null)
            {
                return null;
            }
            //This is a dumb way to update a Drink, because its removing and adding a new one
            //Still working on fixing this

            //Removes the old Drink
            _context.Drinks.Remove(drink);
            await _context.SaveChangesAsync();
            //Adds the updated drink
            _context.Drinks.Add(d);
            await _context.SaveChangesAsync();
            return $"Updated {d.Name}";
        }
      
    }
}
