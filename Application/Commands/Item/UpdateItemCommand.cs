using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Commands
{
    public class UpdateItemCommand : IRequest
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}