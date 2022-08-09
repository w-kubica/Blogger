using Blogger.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Blogger.API.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BloggerContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("BloggerCS")));
        }
    }
}
