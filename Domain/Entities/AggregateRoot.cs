using Domain.Events;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public abstract class AggregateRoot
    {
        public readonly List<IDomainEvent> Events = new List<IDomainEvent>();
        private Guid _id;

        public Guid Id
        {
            get => _id;
            protected set => _id = value == Guid.Empty ? throw new InvalidAggregateRootIdException(value) : value;
        }

        public int Version { get; protected set; }

        protected void AddEvent(IDomainEvent @event)
        {
            if (!Events.Any())
            {
                Version++;
            }

            Events.Add(@event);
        }

        public void ClearEvents() => Events.Clear();
    }
}