using System;
using System.Threading.Tasks;
using CookbookApplication.API.Controllers;
using CookbookApplication.BL.Abstractions;
using CookbookApplication.BL.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace CookbookApplication.Tests.API.Controllers
{
    public class RecipesControllerTests
    {
        private RecipesController _recipesController;
        private Mock<IRecipeService> _recipeService;

        [SetUp]
        public void Init()
        {
            _recipeService = new Mock<IRecipeService>();
            _recipesController = new RecipesController(_recipeService.Object);
        }

        [Test]
        public async Task GetRecipeShouldReturnSuccessResult()
        {
            var id = Guid.NewGuid();
            var recipe = new RecipeModel { Id = id };

            _recipeService.Setup(x => x.GetRecipe(id)).ReturnsAsync(recipe);

            var response = await _recipesController.GetRecipe(id) as OkObjectResult;
            var data = response?.Value as RecipeModel;

            Assert.IsNotNull(response);
            Assert.AreEqual(recipe, data);
            _recipeService.Verify(x => x.GetRecipe(id), Times.Once);
        }

        [Test]
        public async Task GetRecipeShouldReturnNotFoundResult()
        {
            var id = Guid.NewGuid();

            _recipeService.Setup(x => x.GetRecipe(id)).ReturnsAsync((RecipeModel)null);

            var response = await _recipesController.GetRecipe(id) as NotFoundResult;

            Assert.IsNotNull(response);
            _recipeService.Verify(x => x.GetRecipe(id), Times.Once);
        }

        [Test]
        public async Task PutRecipeShouldReturnSuccessResult()
        {
            var id = Guid.NewGuid();
            var recipe = new RecipeModel { Id = id, Title = "Pizza", Description = "Bla bla"};
            _recipeService.Setup(x => x.UpdateRecipe(id, recipe));

            var response = await _recipesController.PutRecipe(id, recipe) as OkResult;

            Assert.IsNotNull(response);
            _recipeService.Verify(x => x.UpdateRecipe(id, recipe), Times.Once);
        }
    }
}