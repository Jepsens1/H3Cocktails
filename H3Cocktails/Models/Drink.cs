using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace H3Cocktails.Models
{
    public class Drink
    {
        //JsonIgnore prevents property to be serialize or deserialize, so when user adds new Drink, ID is not possible to set
        [JsonIgnore]
        //Sets the ID to primary key and auto increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Name { get; set; }

        public List<Ingrediens> Ingrediens { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

    }
}
