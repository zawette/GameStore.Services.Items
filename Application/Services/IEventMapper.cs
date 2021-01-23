using Application.Events;
using Domain.Events;
using System.Collections.Generic;

namespace Application.Services
{
    public interface IEventMapper
    {
        IEvent Map(IDomainEvent @event);

        IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
    }
}