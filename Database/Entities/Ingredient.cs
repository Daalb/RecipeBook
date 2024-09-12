using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Ingredient
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        //Navigation
        public virtual Category Category { get; set; } = new Category();
        public virtual List<Recipe> Recipes { get; } = [];
    }
}
