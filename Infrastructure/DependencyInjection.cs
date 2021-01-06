using Domain.Repositories;
using Infrastructure.Exceptions;
using Infrastructure.Mongo;
using Infrastructure.Mongo.Repositories;
using Microsoft.AspNetCore.Builder;
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

        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
            => services.AddSingleton<IExceptionMapper, ExceptionMapper>()
                       .AddTransient<ErrorHandlingMiddleware>();

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ErrorHandlingMiddleware>();

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
            => services
            .AddMongo()
            .AddErrorHandling();

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app.UseErrorHandling();
    }
}