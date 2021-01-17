using System;
using System.Collections.Generic;
using Domain.ValueObjects;

namespace Application.Events
{
    public class ItemUpdated : IEvent
    {
        public ItemUpdated(Guid id, Category category, string name, string description, double unitPrice, IEnumerable<string> tags)
        {
            Id = id;
            Category = category;
            Name = name;
            Description = description;
            UnitPrice = unitPrice;
            Tags = tags;
        }

        public Guid Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public IEnumerable<string> Tags { get; set; }

    }
}
