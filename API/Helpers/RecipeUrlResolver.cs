using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class RecipeUrlResolver : IValueResolver<Recipe, RecipesToReturnDto, string>
{
    private readonly IConfiguration _config;

    public RecipeUrlResolver(IConfiguration config)
    {
        _config = config;
    }

    public string Resolve(Recipe source, RecipesToReturnDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.PictureUrl))
        {
            return _config["ApiUrl"] + source.PictureUrl;
        }

        return null;
    }
}