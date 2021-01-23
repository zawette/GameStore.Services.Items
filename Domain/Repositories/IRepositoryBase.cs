using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> GetAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<bool> ExistsAsync(Guid id);

        Task AddAsync(T resource);

        Task UpdateAsync(T resource);

        Task DeleteAsync(Guid id);
    }
}