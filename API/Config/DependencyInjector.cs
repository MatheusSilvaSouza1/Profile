using Application.Handlers;
using Domain.Commands;
using Domain.DTOs.Response;
using Domain.Repositories;
using Domain.SeedWork;
using Infra.Repositories;
using MediatR;

namespace API.Config
{
    public static class DependencyInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRequestHandler<CreateUserCommand, ResponseObject<UserCreatedDTO>>, UserHandler>();
            services.AddScoped<IRequestHandler<CreateAddressCommand, ResponseObject<AddressCreatedDTO>>, UserHandler>();
        }
    }
}