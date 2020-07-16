using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookbookApplication.BL.Models;

namespace CookbookApplication.BL.Abstractions
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeModel>> GetRecipesTree();
        Task<IEnumerable<RecipeModel>> GetRecipes(Guid parentId);
        Task<RecipeModel> GetRecipe(Guid recipeId);
        Task CreateRecipe(RecipeModel recipe);
        Task UpdateRecipe(Guid id, RecipeModel recipe);
    }
}