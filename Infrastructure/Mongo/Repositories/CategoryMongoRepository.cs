using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Mongo.Documents;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Mongo.Repositories
{
    public class CategoryMongoRepository : ICategoryRepository
    {
        private readonly IMongoCollection<CategoryDocument> _categories;

        public CategoryMongoRepository(IMongoDbSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _categories = database.GetCollection<CategoryDocument>("Categories");
        }

        public Task AddAsync(Category resource)
            => _categories.InsertOneAsync(resource.asCategoryDocument());

        public Task DeleteAsync(Guid id)
            => _categories.DeleteOneAsync(c => c.Id.Equals(id));

        public Task<bool> ExistsAsync(Guid id)
            => _categories.Find(c => c.Id.Equals(id)).AnyAsync();

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var categoryDocs = await _categories.Find(c => true).ToListAsync();
            return categoryDocs.Select(c => c.asCategory());
        }

        public async Task<Category> GetAsync(Guid id)
        {
            var categoryDoc = await _categories.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();
            return categoryDoc.asCategory();
        }

        public Task UpdateAsync(Category resource)
            => _categories.ReplaceOneAsync(r => r.Id.Equals(resource.Id) && r.Version < resource.Version, resource.asCategoryDocument());
    }
}