using Blogger.Domain.Interfaces;
using Blogger.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blogger.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddScoped<ICosmosPostRepository, CosmosPostRepository>();

            return services;
        }
    }

}
