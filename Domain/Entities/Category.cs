using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Category : AggregateRoot
    {
        public string Name { get; set; }
    }
}
