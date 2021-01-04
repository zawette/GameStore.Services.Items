using Domain.Entities;

namespace Application.DTO
{
    public static class Extensions
    {
        public static ItemDTO asItemDTO(this Item item)
       => new ItemDTO() { Id = item.Id, Category = item.Category, Description = item.Description, Name = item.Name, Tags = item.Tags, UnitPrice = item.UnitPrice };
    }
}