using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RecipeBookContext : DbContext
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

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.Id, ri.IngredientId, ri.RecipeId });



            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Recipes)
                .WithMany(r => r.Ingredients)
                .UsingEntity<RecipeIngredient>(
                    r => r.HasOne<Recipe>().WithMany().OnDelete(DeleteBehavior.NoAction),
                    l => l.HasOne<Ingredient>().WithMany().OnDelete(DeleteBehavior.NoAction)
                );
        }
    }
}
