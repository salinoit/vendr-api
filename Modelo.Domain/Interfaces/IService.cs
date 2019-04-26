using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Vendr.Domain.Interfaces
{
    public interface IService<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T dto);
        Task UpdateAsync(T dto);
        Task DeleteAsync(int id);
    }
}
