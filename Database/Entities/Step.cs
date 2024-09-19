namespace Database.Entities
{
	public class Step
    {
        public Guid StepId { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid RecipeId { get; set; }

        //Navigations
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
