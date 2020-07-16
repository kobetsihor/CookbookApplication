using System;
using System.Threading.Tasks;
using AutoMapper;
using CookbookApplication.BL.Abstractions;
using CookbookApplication.BL.Models;
using CookbookApplication.BL.Services;
using CookbookApplication.DAL.Entities;
using CookbookApplication.DAL.Repositories;
using Moq;
using NUnit.Framework;

namespace CookbookApplication.Tests.BL.Services
{
    public class RecipeServiceTests
    {
        private IRecipeService _recipeService;
        private Mock<IRecipeRepository> _recipeRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Init()
        {
            _mapperMock = new Mock<IMapper>();
            _recipeRepositoryMock = new Mock<IRecipeRepository>();
            _recipeService = new RecipeService(_recipeRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task GetRecipeShouldReturnModel()
        {
            var id = Guid.NewGuid();
            var recipe = new Recipe { Id = id };
            var recipeModel = new RecipeModel { Id = id };
            
            _recipeRepositoryMock.Setup(x => x.Get(id)).ReturnsAsync(recipe);
            _mapperMock.Setup(x => x.Map<RecipeModel>(recipe)).Returns(recipeModel);

            var result = await _recipeService.GetRecipe(id);

            Assert.AreEqual(recipeModel, result);
            _recipeRepositoryMock.Verify(x => x.Get(id), Times.Once);
        }
    }
}