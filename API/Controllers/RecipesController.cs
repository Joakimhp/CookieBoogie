using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class RecipesController : BaseApiController
{
    private readonly CookbookContext _context;

    public RecipesController(CookbookContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Recipe>>> GetRecipes()
    {
        var recipes = await _context.Recipes
            .Include(r => r.RecipeType)
            .ToListAsync();
        return Ok(recipes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Recipe>> GetRecipe(int id)
    {
        return await _context.Recipes
            .Include(r => r.RecipeType)
            .SingleOrDefaultAsync(r => r.Id == id);
    }
    
    [HttpGet]
    public async Task<ActionResult<RecipeType>> GetRecipeTypes()
    {
        var recipeTypes = await _context.RecipeTypes.ToListAsync();
        return Ok(recipeTypes);
    }
}