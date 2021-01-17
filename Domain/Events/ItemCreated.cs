using Domain.Entities;

namespace Domain.Events
{
    public class ItemCreated : IDomainEvent
    {
        public Item item { get; }

        public ItemCreated(Item item)
        {
            this.item = item;
        }
    }
}