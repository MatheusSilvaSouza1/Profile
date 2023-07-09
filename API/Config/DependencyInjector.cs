using Domain.Repositories;
using Infra.Repositories;

namespace API.Config
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}