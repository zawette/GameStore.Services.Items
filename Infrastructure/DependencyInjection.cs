using Application.Services;
using Domain.Repositories;
using Infrastructure.Exceptions;
using Infrastructure.Messaging;
using Infrastructure.Mongo;
using Infrastructure.Mongo.Repositories;
using Infrastructure.Services;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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

        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RabbitMqSettings>(options => config.GetSection("RabbitMqSettings"));
            services.AddSingleton<RabbitMqSettings>(sp=> sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value);
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                var rabbitMqSettings=provider.GetRequiredService<RabbitMqSettings>();
                    cfg.UseHealthCheck(provider);
                    cfg.Host(new Uri($"rabbitmq://{rabbitMqSettings.host}"), h =>
                                   {
                                       h.Username(rabbitMqSettings.username);
                                       h.Password(rabbitMqSettings.password);
                                   });
                }));
            });
            services.AddMassTransitHostedService();
            services.AddSingleton<IEventMapper, EventMapper>();
            services.AddTransient<IMessageBroker, MessageBroker>();
            services.AddTransient<IEventProcessor, EventProcessor>();
            return services;
        }
        public static IServiceCollection AddErrorHandling(this IServiceCollection services)
            => services.AddSingleton<IExceptionMapper, ExceptionMapper>()
                       .AddTransient<ErrorHandlingMiddleware>();

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder app)
            => app.UseMiddleware<ErrorHandlingMiddleware>();

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
            => services
            .AddMongo()
            .AddMessaging(config)
            .AddErrorHandling();


        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
            => app.UseErrorHandling();
    }
}