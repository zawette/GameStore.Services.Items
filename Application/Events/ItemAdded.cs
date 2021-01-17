using System;

namespace Application.Events
{
    public class ItemAdded : IEvent
    {
        public Guid Id { get; set; }

        public ItemAdded(Guid id)
        {
            Id = id;
        }
    }
}
