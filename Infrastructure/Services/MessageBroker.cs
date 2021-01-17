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
        public Task PublishAsync(IEnumerable<IEvent> events)
        {
            throw new NotImplementedException();
        }
    }
}
