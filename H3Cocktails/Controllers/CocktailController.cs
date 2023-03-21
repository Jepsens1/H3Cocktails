using H3Cocktails.Handler;
using H3Cocktails.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H3Cocktails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CocktailController : ControllerBase
    {

        private DrinkHandler _drinkHandler;
        public CocktailController(DrinkHandler handler)
        {
            _drinkHandler = handler;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<List<Drink>>> GetDrinks()
        {
            var drinks = await _drinkHandler.GetAllDrinks();
            if(drinks == null)
            {
                return NotFound();
            }
            return Ok(drinks);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult<Drink>> AddDrink(Drink d)
        {
            var drink = await _drinkHandler.AddDrink(d);
            if(drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<ActionResult<Drink>> GetDrink(string name)
        {
            var drink = await _drinkHandler.GetDrink(name);
            if(drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<ActionResult<string>> DeleteDrink(string name)
        {
            var drink = await _drinkHandler.RemoveDrink(name);
            if(drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }
    }
}
