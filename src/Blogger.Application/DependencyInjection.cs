using Blogger.Application.Interfaces;
using Blogger.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Blogger.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IPostService, PostService>();
            services.AddScoped<ICosmosPostService, CosmosPostService>();
            return services;
        }
     }
}
