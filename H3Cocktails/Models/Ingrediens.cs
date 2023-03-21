using System.ComponentModel.DataAnnotations;

namespace H3Cocktails.Models
{
    public class Ingrediens
    {
        [Key]
        public string Name { get;  set; }

        public double Amount { get;  set; }

        public Ingrediens()
        {

        }
    }
}
