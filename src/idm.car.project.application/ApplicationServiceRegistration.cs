using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace idm.car.project.application;

public static class ApplicationServiceRegistration
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
        });


        return services;
    }

}
