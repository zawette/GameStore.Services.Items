using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class ItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Category Category { get; set; }
        public double UnitPrice { get; set; }
    }
}