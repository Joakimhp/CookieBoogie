using System.Reflection;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class RecipesController : BaseApiController
{
    private readonly IGenericRepository<Recipe> _recipeRepo;
    private readonly IGenericRepository<RecipeType> _recipeTypeRepo;
    private readonly IMapper _mapper;

    public RecipesController(
        IGenericRepository<Recipe> recipeRepo,
        IGenericRepository<RecipeType> recipeTypeRepo,
        IMapper mapper)
    {
        _recipeRepo = recipeRepo;
        _recipeTypeRepo = recipeTypeRepo;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<RecipesToReturnDto>>> GetRecipes()
    {
        var spec = new RecipesWithTypesSpecification();

        var recipes = await _recipeRepo.ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<Recipe>, IReadOnlyList<RecipesToReturnDto>>(recipes));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<RecipesToReturnDto>> GetRecipe(int id)
    {
        var spec = new RecipesWithTypesSpecification(id);
        
        var recipe = await _recipeRepo.GetEntityWithSpec(spec);
        
        return _mapper.Map<Recipe, RecipesToReturnDto>(recipe);
    }
    
    [HttpGet("/types")]
    public async Task<ActionResult<RecipeType>> GetRecipeTypes()
    {
        var recipeTypes = await _recipeTypeRepo.ListAllAsync();
        return Ok(recipeTypes);
    }
}