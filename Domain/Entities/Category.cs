using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : AggregateRoot
    {
        public string Name { get; set; }

        public Category(Guid id,string name,int version)
        {
            Name = name;
            Version = version;
            Id = id;
        }
    }
}
