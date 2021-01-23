using System;

namespace Application.Events
{
    public class ItemRemoved : IEvent
    {
        public Guid Id { get; set; }

        public ItemRemoved(Guid id)
        {
            Id = id;
        }
    }
}