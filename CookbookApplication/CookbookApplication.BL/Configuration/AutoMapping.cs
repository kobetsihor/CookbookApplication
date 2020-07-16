using AutoMapper;
using CookbookApplication.BL.Models;
using CookbookApplication.DAL.Entities;

namespace CookbookApplication.BL.Configuration
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Recipe, RecipeModel>()
                .ReverseMap()
                .ForMember(x => x.Children, opt => opt.Ignore());
        }
    }
}