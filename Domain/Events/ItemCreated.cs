namespace Domain.Entities
{
    public class ItemCreated : IDomainEvent
    {
        public Item item;

        public ItemCreated(Item item)
        {
            this.item = item;
        }
    }
}