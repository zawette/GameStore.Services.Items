using Application.Services;
using Domain.Events;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IMessageBroker _messageBroker;
        private readonly ILogger<IEventProcessor> _logger;
        private readonly IEventMapper _eventMapper;

        public EventProcessor(IMessageBroker messageBroker, ILogger<IEventProcessor> logger, IEventMapper eventMapper)
        {
            _messageBroker = messageBroker;
            _logger = logger;
            _eventMapper = eventMapper;
        }

        public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            if (events is null) { return; }
            var appEvents = _eventMapper.MapAll(events);
            if (!appEvents.Any())
            { return; }
            _logger.LogTrace("publishing event");
            await _messageBroker.PublishAsync(appEvents);
        }
    }
}