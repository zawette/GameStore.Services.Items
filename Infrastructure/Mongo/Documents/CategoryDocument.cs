using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Infrastructure.Mongo.Documents
{
    public class CategoryDocument
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Version { get; set; }
    }
}