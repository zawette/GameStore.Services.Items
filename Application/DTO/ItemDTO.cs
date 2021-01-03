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
        public string Category { get; set; }
    }
}