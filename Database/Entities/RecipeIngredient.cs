using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Entities
{
    public class RecipeIngredient
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string QuantityDescription { get; set; } = string.Empty;

        //Nagivation
        public Recipe Recipe { get; set; } = new Recipe();
        public Ingredient Ingredient { get; set; } = new Ingredient();

    }
}
