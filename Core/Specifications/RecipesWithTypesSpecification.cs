using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class RecipesWithTypesSpecification : BaseSpecification<Recipe>
{
    public RecipesWithTypesSpecification()
    {
        AddInclude(recipe => recipe.RecipeType);
    }

    public RecipesWithTypesSpecification(int id) 
        : base(x => x.Id == id)
    {
        AddInclude(recipe => recipe.RecipeType);
    }
}