using System;
using System.Threading.Tasks;
using CookbookApplication.BL.Abstractions;
using CookbookApplication.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRecipesTree()
        {
            return Ok(await _recipeService.GetRecipesTree());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecipe(Guid id)
        {
            var recipe = await _recipeService.GetRecipe(id);
            if (recipe == null)
            {
                return NotFound();
            }

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<IActionResult> PostRecipe(RecipeModel recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _recipeService.CreateRecipe(recipe);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(Guid id, RecipeModel recipe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _recipeService.UpdateRecipe(id, recipe);
            return Ok();
        }
    }
}