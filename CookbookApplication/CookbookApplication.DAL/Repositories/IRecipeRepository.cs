using System;
using System.Linq;
using System.Threading.Tasks;
using CookbookApplication.DAL.Entities;

namespace CookbookApplication.DAL.Repositories
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> GetAll();
        Task<Recipe> Get(Guid id);
        Task Add(Recipe recipe);
        Task Update(Recipe recipe);
    }
}