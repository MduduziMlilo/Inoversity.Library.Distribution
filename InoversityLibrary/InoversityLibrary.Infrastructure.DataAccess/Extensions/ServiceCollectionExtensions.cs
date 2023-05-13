using InoversityLibrary.Application.Interfaces.Repositories;
using InoversityLibrary.DataAccess.Contexts;
using InoversityLibrary.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InoversityLibrary.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString,
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
            .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddTransient<IDocumentRepository, DocumentRepository>();
    }
}