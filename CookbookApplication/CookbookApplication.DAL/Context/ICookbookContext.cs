using System.Threading.Tasks;
using CookbookApplication.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CookbookApplication.DAL.Context
{
    public interface ICookbookContext
    {
        DbSet<Recipe> Recipes { get; set; }
        Task<IDbContextTransaction> BeginTransaction();
        Task SaveChanges();
    }
}