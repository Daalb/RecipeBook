using Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database
{
	public class RecipeBookContext : IdentityDbContext<User>
	{
		public RecipeBookContext(DbContextOptions<RecipeBookContext> options) : base(options)
		{
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Recipe> Recipes { get; set; }
		public DbSet<Step> Steps { get; set; }
		public DbSet<RecipeIngredient> RecipesIngredients { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//Entity Configurations
			modelBuilder.Entity<Category>(entity =>
			{
				entity.HasKey(c => c.CategoryId);

				entity.Property(c => c.Name)
					.HasMaxLength(50);

				entity.Property(c => c.Description)
				.HasMaxLength(250);

				entity.Property(c => c.Type)
				.HasMaxLength(50);
			});

			modelBuilder.Entity<Ingredient>(entity =>
			{
				entity.HasKey(i => i.IngredientId);

				entity.Property(i => i.Name)
				.HasMaxLength(50);
			});

			modelBuilder.Entity<Recipe>(entity =>
			{
				entity.HasKey(r => r.RecipeId);

				entity.Property(c => c.Name)
					.HasMaxLength(50);

				entity.Property(c => c.Description)
				.HasMaxLength(250);
			});

			modelBuilder.Entity<Step>(entity =>
			{
				entity.HasKey(s => s.StepId);

				entity.Property(s => s.Description)
				.HasMaxLength(500);
			});

			modelBuilder.Entity<RecipeIngredient>(entity =>
			{
				entity.HasKey(ri => new { ri.RecipeIngredientId });

				entity.Property(ri => ri.QuantityDescription)
				.HasMaxLength(50);
			});


			//Relationships
			modelBuilder.Entity<Category>()
				.HasMany(c => c.Recipes)
				.WithOne(r => r.Category)
				.HasForeignKey(r => r.CategoryId)
				.IsRequired();

			modelBuilder.Entity<Recipe>()
				.HasMany(r => r.Steps)
				.WithOne(s => s.Recipe)
				.HasForeignKey(s => s.RecipeId)
				.IsRequired();

			modelBuilder.Entity<Recipe>()
				.HasMany(r => r.Ingredients)
				.WithMany(i => i.Recipes)
				.UsingEntity<RecipeIngredient>();


			//modelBuilder.Entity<Ingredient>()
			//    .HasMany(i => i.Recipes)
			//    .WithMany(r => r.Ingredients)
			//    .UsingEntity<RecipeIngredient>(
			//        r => r.HasOne<Recipe>().WithMany().OnDelete(DeleteBehavior.NoAction),
			//        l => l.HasOne<Ingredient>().WithMany().OnDelete(DeleteBehavior.NoAction)
			//    );
		}
	}
}
