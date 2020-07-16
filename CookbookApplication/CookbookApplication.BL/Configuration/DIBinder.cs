using CookbookApplication.BL.Abstractions;
using CookbookApplication.BL.Services;
using CookbookApplication.DAL.Context;
using CookbookApplication.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CookbookApplication.BL.Configuration
{
    public static class DIBinder
    {
        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeService, RecipeService>();
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            string connection = "Server=cool_server;Database=TransactionsDb;Trusted_Connection=True;";
            services.AddDbContext<ICookbookContext, CookbookContext>(options => options.UseSqlServer(connection));
        }
    }
}