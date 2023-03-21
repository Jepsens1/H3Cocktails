using System.ComponentModel.DataAnnotations;

namespace H3Cocktails.Models
{
    public class Drink
    {
        [Key]
        public string Name { get; set; }

        public List<Ingrediens> Ingrediens { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

    }
}
