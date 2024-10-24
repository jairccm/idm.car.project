using idm.car.project.application.Contracts.Persistence;
using idm.car.project.infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace idm.car.project.infraestructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddSingleton<ICartRepository, CartRepository>();

        return services;
    }

}
