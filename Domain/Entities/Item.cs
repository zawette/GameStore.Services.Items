using Domain.Entities.Events;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Item : AggregateRoot
    {
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        private ISet<string> _tags = new HashSet<string>();

        public IEnumerable<string> Tags
        {
            get => _tags;
            private set => _tags = new HashSet<string>(value);
        }

        public Item(Guid Id, Category category, string name, string description, IEnumerable<string> tags, double unitPrice, int version = 0)
        {
            this.Id = Id;
            this.Version = version;
            Category = category;
            Name = name;
            Description = description;
            Tags = tags;
            UnitPrice = unitPrice;
        }

        public static Item Create(Guid Id, Category category, string name, string description, IEnumerable<string> tags, double unitPrice)
        {
            var item = new Item(Id, category, name, description, tags, unitPrice);
            item.AddEvent(new ItemCreated(item));
            return item;
        }

        public void Delete(Item item)
        {
            item.AddEvent(new ItemDeleted(item));
        }
    }
}