using System;
using System.Threading.Tasks;
using CookbookApplication.DAL.Context;
using CookbookApplication.DAL.Entities;
using CookbookApplication.DAL.Repositories;
using Moq;
using NUnit.Framework;

namespace CookbookApplication.Tests.DAL.Repositories
{
    public class RecipeRepositoryTests
    {
        private IRecipeRepository _recipeRepository;
        private Mock<ICookbookContext> _cookbookContextMock;

        [SetUp]
        public void Init()
        {
            _cookbookContextMock = new Mock<ICookbookContext>();
            _recipeRepository = new RecipeRepository(_cookbookContextMock.Object);
        }

        [Test]
        public async Task GetShouldReturnEntity()
        {
            var id = Guid.NewGuid();
            var recipe = new Recipe {Id = id};

            _cookbookContextMock.Setup(x => x.Recipes.FindAsync(id)).ReturnsAsync(recipe);

            var result = await _recipeRepository.Get(id);

            Assert.AreEqual(recipe, result);
            _cookbookContextMock.Verify(x => x.Recipes.FindAsync(id), Times.Once);
        }


    }
}