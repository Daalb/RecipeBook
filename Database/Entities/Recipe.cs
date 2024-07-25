using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Servings { get; set; }
        public float PreparationTime { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }

        //Navigation
        public virtual Category Category { get; set; } = null!;
        public virtual List<Step> Steps { get; } = [];
        public virtual List<Ingredient> Ingredients { get; } = [];
        public virtual List<RecipeIngredient> RecipeIngredients { get; } = [];

    }
}
