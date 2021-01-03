using Domain.Repositories;
using Infrastructure.Mongo;
using Infrastructure.Mongo.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        private static IServiceCollection AddMongo(this IServiceCollection services)
        {
            var ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var DatabaseName = Environment.GetEnvironmentVariable("DatabaseName");
            services.AddSingleton<IMongoDbSettings>(sp => new MongoDbSettings(DatabaseName, ConnectionString));
            services.AddSingleton<IMongoClient>(sp => new MongoClient(ConnectionString));
            services.AddSingleton<IItemRepository, ItemMongoRepository>();
            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddMongo();
            return services;
        }
    }
}