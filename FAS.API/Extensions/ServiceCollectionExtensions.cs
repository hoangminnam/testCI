
using FAS.BLL.BusinessService;
using FAS.BLL.BusinessInterfaces;
using FAS.DAL.Repositories;
using FAS.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FAS.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //repository
            services.AddSingleton(configuration);
            services.AddScoped<IAwardCategoryRepository, AwardCategoryRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();

            //services
            services.AddScoped<IAwardCategoryService, AwardCategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<INomineeRepository, NomineeRepository>();
            services.AddScoped<INomineeService, NomineeService>();

            return services;
        }
    }
}