using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Mongo.Documents;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Mongo.Repositories
{
    public class ItemMongoRepository : IItemRepository
    {
        private readonly IMongoCollection<ItemDocument> _items;

        public ItemMongoRepository(IMongoDbSettings settings, IMongoClient mongoClient)
        {
            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;

            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _items = database.GetCollection<ItemDocument>("Items");
        }

        public Task AddAsync(Item resource)
            => _items.InsertOneAsync(resource.asItemDocument());

        public Task DeleteAsync(Guid id)
            => _items.DeleteOneAsync(i => i.Id.Equals(id));

        public Task<bool> ExistsAsync(Guid id)
            => _items.Find(i => i.Id.Equals(id)).AnyAsync();

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            var itemDocs = await _items.Find(i => true).ToListAsync();
            return itemDocs.Select(i => i.asItem());
        }

        public async Task<Item> GetAsync(Guid id)
        {
            var itemDoc = await _items.Find(i => i.Id == id).FirstOrDefaultAsync();
            return itemDoc?.asItem();
        }

        public Task UpdateAsync(Item resource)
            => _items.ReplaceOneAsync(r => r.Id.Equals(resource.Id) && r.Version < resource.Version, resource.asItemDocument());
    }
}