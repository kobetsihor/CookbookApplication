using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookbookApplication.BL.Abstractions;
using CookbookApplication.BL.Models;
using CookbookApplication.DAL.Entities;
using CookbookApplication.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CookbookApplication.BL.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepository recipeRepository, IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipesTree()
        {
            var recipes = await _recipeRepository.GetAll()
                                                           .Where(x => x.Parent == null)
                                                           .OrderBy(x => x.Title)
                                                           .ToListAsync();

            return _mapper.Map<IEnumerable<RecipeModel>>(recipes);
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes(Guid parentId)
        {
            var recipes = await _recipeRepository.GetAll()
                                                           .Where(x => x.ParentId == parentId)
                                                           .OrderBy(x => x.Title)
                                                           .ToListAsync();

            return _mapper.Map<IEnumerable<RecipeModel>>(recipes);
        }

        public async Task<RecipeModel> GetRecipe(Guid recipeId)
        {
            var recipe = await _recipeRepository.Get(recipeId);
            return _mapper.Map<RecipeModel>(recipe);
        }

        public async Task CreateRecipe(RecipeModel recipeModel)
        {
            var recipe = _mapper.Map<Recipe>(recipeModel);
            await _recipeRepository.Add(recipe);
        }

        public async Task UpdateRecipe(Guid id, RecipeModel recipeModel)
        {
            var recipe = await _recipeRepository.Get(id);
            if (recipe == null)
            {
                throw new Exception($"Entity with id {id} not found");;
            }
            
            _mapper.Map(recipeModel, recipe);
            await _recipeRepository.Update(recipe);
        }
    }
}