using InoversityLibrary.Application.Interfaces;
using InoversityLibrary.Domain.Common;
using InoversityLibrary.Domain.Common.Interfaces;
using InoversityLibrary.Infrastructure.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InoversityLibrary.Infrastructure.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddServices();
    }

    private static void AddServices(this IServiceCollection services)
    {
        services
            .AddTransient<IMediator, Mediator>()
            .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
            .AddTransient<IDateTimeService, DateTimeService>();
    }
}