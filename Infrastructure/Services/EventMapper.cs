using System;
using System.Collections.Generic;
using System.Linq;
using Application.Events;
using Application.Services;
using Domain.Entities;
using Domain.Events;

namespace Infrastructure.Services
{
    public class EventMapper : IEventMapper
    {
        public IEvent Map(IDomainEvent @event)
            => @event switch
            {
                ItemCreated e => new ItemAdded(e.item.Id),
                ItemDeleted e => new ItemRemoved(e.item.Id),
                ItemModified e => new ItemUpdated(e.item.Id, e.item.Category, e.item.Name, e.item.Description, e.item.UnitPrice, e.item.Tags),
                _ => null
            };

        public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
            => events.Select(Map);
    }
}
