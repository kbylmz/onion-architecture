using Hestia.Application.Config;
using Hestia.Application.Contracts.Contexts;
using Hestia.Application.Contracts.Readers;
using Hestia.Application.Contracts.Repositories;
using Hestia.Infrastructure.DbContexts;
using Hestia.Infrastructure.Readers;
using Hestia.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Hestia.Infrastructure.Config
{
    public static class Bootstrapper
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, Settings settings)
        {
            AddPersistenceContexts(services, settings);
            AddRepositories(services, settings);
            AddReaders(services, settings);
        }

        private static void AddPersistenceContexts(this IServiceCollection services, Settings settings)
        {
            services.AddScoped<IDbContext>(p => new MongoContext(
                new MongoClient(settings.DatabaseSettings.ConnectionString),
                settings.DatabaseSettings.DatabaseName
            ));
        }

        private static void AddRepositories(this IServiceCollection services, Settings settings)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        private static void AddReaders(this IServiceCollection services, Settings settings)
        {
            services.AddTransient<IProductReader>(p => new ProductReader(
                new MongoClient(settings.DatabaseSettings.ConnectionString),
                settings.DatabaseSettings.DatabaseName
            ));

            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
