using Domain.Entities;

namespace Domain.Events
{
    public class ItemDeleted : IDomainEvent
    {
        public Item item { get; }

        public ItemDeleted(Item item)
        {
            this.item = item;
        }
    }
}