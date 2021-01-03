using Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Infrastructure.Mongo.Documents
{
    public class ItemDocument
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }

        public IEnumerable<string> Tags { get; set; }
        public int Version { get; set; }
        public Category Category { get; set; }
    }
}