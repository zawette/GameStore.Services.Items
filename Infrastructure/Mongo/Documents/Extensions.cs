using Domain.Entities;

namespace Infrastructure.Mongo.Documents
{
    public static class Extensions
    {
        public static Item asItem(this ItemDocument itemDocument)
            => new Item(itemDocument.Id, itemDocument.CategoryId, itemDocument.Name, itemDocument.Description, itemDocument.Tags, itemDocument.Version);

        public static ItemDocument asItemDocument(this Item item)
     => new ItemDocument() { Id = item.Id, CategoryId = item.CategoryId, Description = item.Description, Name = item.Name, Tags = item.Tags, Version = item.Version };

        public static Category asCategory(this CategoryDocument categoryDocument)
    => new Category(categoryDocument.Id, categoryDocument.Name, categoryDocument.Version);

        public static CategoryDocument asCategoryDocument(this Category category)
     => new CategoryDocument() { Id = category.Id, Name = category.Name, Version = category.Version };
    }
}