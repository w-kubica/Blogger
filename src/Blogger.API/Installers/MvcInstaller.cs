using Blogger.Application;
using Blogger.Application.Interfaces;
using Blogger.Application.Mappings;
using Blogger.Application.Services;
using Blogger.Domain.Interfaces;
using Blogger.Infrastructure;
using Blogger.Infrastructure.Repositories;

namespace Blogger.API.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddApplication();
            services.AddInfrastructure();

            services.AddControllers();

        }
    }
}
