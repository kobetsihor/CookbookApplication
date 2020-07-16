using System;
using System.Linq;
using System.Threading.Tasks;
using CookbookApplication.DAL.Context;
using CookbookApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookbookApplication.DAL.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ICookbookContext _context;

        public RecipeRepository(ICookbookContext context)
        {
            _context = context;
        }

        public IQueryable<Recipe> GetAll()
        {
            return _context.Recipes.AsNoTracking();
        }

        public async Task<Recipe> Get(Guid id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task Add(Recipe entity)
        {
            await using var transaction = await _context.BeginTransaction();
            try
            {
                await _context.Recipes.AddAsync(entity);
                await _context.SaveChanges();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }

        public async Task Update(Recipe entity)
        {
            await using var transaction = await _context.BeginTransaction();
            try
            {
                _context.Recipes.Update(entity);
                await _context.SaveChanges();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
            finally
            {
                await transaction.DisposeAsync();
            }
        }
    }
}