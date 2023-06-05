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
        var recipes = await _context.Recipes.ToListAsync();
        return Ok(recipes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Recipe>> GetRecipe(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);
        return Ok(recipe);
    }
}