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
        public static IServiceCollection addMongo(this IServiceCollection services)
        {
            var ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
            var DatabaseName = Environment.GetEnvironmentVariable("DatabaseName");
            services.AddSingleton<IMongoDbSettings>(sp => new MongoDbSettings(DatabaseName, ConnectionString));
            services.AddSingleton<IMongoClient>(sp => new MongoClient(ConnectionString));
            services.AddSingleton<IItemRepository, ItemMongoRepository>();
            services.AddSingleton<ICategoryRepository, CategoryMongoRepository>();
            return services;
        }

        public static IServiceCollection addInfrastructure(this IServiceCollection services)
        {
            services.addMongo();
            return services;
        }
    }
}