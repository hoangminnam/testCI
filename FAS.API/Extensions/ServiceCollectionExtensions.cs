
using FAS.BLL.BusinessService;
using FAS.BLL.BusinessInterfaces;
using FAS.DAL.Repositories;
using FAS.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FAS.API.Controllers;

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
            services.AddSingleton(configuration);

            //repository
            services.AddScoped<IAwardCategoryRepository, AwardCategoryRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<INomineeRepository, NomineeRepository>();
            services.AddScoped<ICommentNomineeRepository, CommentNomineeRepository>();
            services.AddScoped<INominateActionLogRepository, NominateActionLogRepository>();
            services.AddScoped<ICouncilMemberRepository, CouncilMemberRepository>();

            //services
            services.AddScoped<IAwardCategoryService, AwardCategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<INomineeService, NomineeService>();
            services.AddScoped<ICommentNomineeService, CommentNomineeService>();
            services.AddScoped<INominateActionLogService, NominateActionLogService>();
            services.AddScoped<ICouncilMemberService, CouncilMemberService>();

            return services;
        }
    }
}