namespace Database.Entities
{
	public class Recipe
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Servings { get; set; }
        public float PreparationTime { get; set; }
        public Guid CategoryId { get; set; }

        //Navigation
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<Step> Steps { get; } = [];
        public virtual ICollection<Ingredient> Ingredients { get; } = [];

    }
}
