using Domain.Entities;

namespace Domain.Events
{
    public class ItemModified : IDomainEvent
    {
        public Item item { get; }

        public ItemModified(Item item)
        {
            this.item = item;
        }
    }
}