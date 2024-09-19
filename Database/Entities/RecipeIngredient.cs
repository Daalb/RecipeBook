namespace Database.Entities
{
	public class RecipeIngredient
    {
        public Guid RecipeIngredientId { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public string QuantityDescription { get; set; } = string.Empty;

    }
}
