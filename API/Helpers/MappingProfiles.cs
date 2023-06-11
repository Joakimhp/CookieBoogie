using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Recipe, RecipesToReturnDto>()
            .ForMember(d => d.RecipeType, o => o.MapFrom(s => s.RecipeType.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<RecipeUrlResolver>());
    }
}