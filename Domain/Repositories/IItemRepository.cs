using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IItemRepository
    {
        Task<Item> GetAsync(Guid id);

        Task<IEnumerable<Item>> GetAllAsync();

        Task<bool> ExistsAsync(Guid id);

        Task AddAsync(Item resource);

        Task UpdateAsync(Item resource);

        Task DeleteAsync(Guid id);
    }
}