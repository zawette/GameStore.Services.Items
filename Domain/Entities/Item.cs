using Domain.Entities.Events;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Item : AggregateRoot
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        private ISet<string> _tags = new HashSet<string>();

        public IEnumerable<string> Tags
        {
            get => _tags;
            private set => _tags = new HashSet<string>(value);
        }

        public Item(Guid Id, Guid categoryId, string name, string description, IEnumerable<string> tags, int version = 0)
        {
            this.Id = Id;
            this.Version = version;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Tags = tags;
        }

        public static Item Create(Guid Id, Guid categoryId, string name, string description, IEnumerable<string> tags)
        {
            var item = new Item(Id, categoryId, name, description, tags);
            item.AddEvent(new ItemCreated(item));
            return item;
        }

        public void Delete(Item item)
        {
            item.AddEvent(new ItemDeleted(item));
        }
    }
}