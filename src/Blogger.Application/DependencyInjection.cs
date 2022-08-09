using System.Reflection;
using Blogger.Application.Interfaces;
using Blogger.Application.Mappings;
using Blogger.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blogger.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IPostService, PostService>();

            return services;
        }
    }
}
