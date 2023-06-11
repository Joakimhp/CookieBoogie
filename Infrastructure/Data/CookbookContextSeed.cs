using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class CookbookContextSeed
{
    public static async Task SeedAsync(CookbookContext context)
    {
        if(!context.RecipeTypes.Any())
        {
            var recipeTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/recipeTypes.json");
            var recipeTypes = JsonSerializer.Deserialize<List<RecipeType>>(recipeTypesData);

            context.RecipeTypes.AddRange(recipeTypes);

            await context.SaveChangesAsync();
        }
        
        if(!context.Recipes.Any())
        {
            var recipesData = File.ReadAllText("../Infrastructure/Data/SeedData/recipes.json");
            var recipes = JsonSerializer.Deserialize<List<Recipe>>(recipesData);

            context.Recipes.AddRange(recipes);
        }

        if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
}