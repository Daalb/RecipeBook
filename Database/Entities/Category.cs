namespace Database.Entities
{
	public class Category
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;

        //Navigation
        public virtual ICollection<Recipe> Recipes { get; } = [];
    }
}
