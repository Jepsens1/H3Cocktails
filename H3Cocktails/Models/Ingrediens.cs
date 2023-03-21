using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace H3Cocktails.Models
{
    public class Ingrediens
    {
        //JsonIgnore prevents property to be serialize or deserialize, so when user adds new Drink, ID is not possible to set
        [JsonIgnore]
        //Sets the ID to primary key and auto increment
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get;  set; }

        public double Amount { get;  set; }
    }
}
