using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Events;
using Application.Services;
using Infrastructure.Messaging;
using MassTransit;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class MessageBroker : IMessageBroker
    {
       private readonly RabbitMqSettings _mqOptions ;
       private readonly IBus _bus;

        public MessageBroker(IOptions<RabbitMqSettings> mqOptions, IBus bus)
        {
            _mqOptions = mqOptions.Value;
            _bus = bus;
        }

        public Task PublishAsync(params IEvent[] events)
            => PublishAsync(events?.AsEnumerable());
        public async Task PublishAsync(IEnumerable<IEvent> events)
        {
            foreach (var @event in events)
            {
               Uri uri = new Uri($"rabbitmq://{_mqOptions.host}/{_mqOptions.queue}.{nameof(@event)}"); 
               var endPoint = await _bus.GetSendEndpoint(uri);
               await endPoint.Send(@event);
            }
        }
    }
}
