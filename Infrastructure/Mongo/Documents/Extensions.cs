using Domain.Entities;

namespace Infrastructure.Mongo.Documents
{
    public static class Extensions
    {
        public static Item asItem(this ItemDocument itemDocument)
            => new Item(itemDocument.Id, itemDocument.Category, itemDocument.Name, itemDocument.Description, itemDocument.Tags, itemDocument.UnitPrice, itemDocument.Version);

        public static ItemDocument asItemDocument(this Item item)
            => new ItemDocument() { Id = item.Id, Category = item.Category, Description = item.Description, Name = item.Name, Tags = item.Tags, UnitPrice = item.UnitPrice, Version = item.Version };
    }
}