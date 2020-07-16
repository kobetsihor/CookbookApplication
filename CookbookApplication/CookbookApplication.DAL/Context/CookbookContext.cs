using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using CookbookApplication.DAL.Entities;

namespace CookbookApplication.DAL.Context
{
    public class CookbookContext : DbContext, ICookbookContext
    {
        public CookbookContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Recipe> Recipes { get; set; }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await Database.BeginTransactionAsync();
        }

        public new async Task SaveChanges()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                        .HasData(new Recipe { Id = Guid.NewGuid(), Title= "Pizza", Description= "Bla", DateCreated = DateTimeOffset.Now},
                                 new Recipe { Id= Guid.NewGuid(), Title = "Spaghetti", Description= "Bla Bla", DateCreated = DateTimeOffset.Now },
                                 new Recipe { Id= Guid.NewGuid(), Title= "Lasagna", Description = "Bla Bla Bla", DateCreated = DateTimeOffset.Now });
        }
    }
}