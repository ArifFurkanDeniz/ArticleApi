using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ArticleProject.Entities.Models;

namespace ArticleProject.Api.Configuration
{
    public static class DbContext
    {
        public static void AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ArticleDBContext>(options => options.UseSqlServer(connectionString));
        }
    }
}