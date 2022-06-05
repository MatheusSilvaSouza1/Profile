using Application.Profiles;

namespace API.Config
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile).Assembly);
        }
    }
}