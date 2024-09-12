using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities
{
    public class RecipeIngredient
    {
        public Guid Id { get; set; }
        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
        [ForeignKey(nameof(Ingredient))]
        public Guid IngredientId { get; set; }
        public string QuantityDescription { get; set; } = string.Empty;

        //Nagivation
        public Ingredient Ingredient { get; set; } = new Ingredient();
        public Recipe Recipe { get; set; } = new Recipe();

    }
}
