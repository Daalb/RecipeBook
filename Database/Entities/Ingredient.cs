namespace Database.Entities
{
	public class Ingredient
    {
        public Guid IngredientId { get; set; }
        public string Name { get; set; } = string.Empty;

        //Navigation
        public virtual ICollection<Recipe> Recipes { get; } = [];
    }
}
