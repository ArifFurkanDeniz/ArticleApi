using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ArticleProject.Business;
using ArticleProject.Business.Interfaces;
using ArticleProject.Core.Security;
using ArticleProject.Repository.Generic;
using ArticleProject.Repository.UnitOfWork;

namespace ArticleProject.Api.Configuration
{
    public static class Service
    {
        /// <summary>
        /// Uygulama ayağa kalktığında bağımlılıkları inject eder
        /// </summary>
        /// <param name="services"></param>
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IArticleService, ArticleService>();

            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
