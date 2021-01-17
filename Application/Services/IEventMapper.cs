using System;
using System.Collections.Generic;
using Application.Events;
using Domain.Events;

namespace Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);
        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}
