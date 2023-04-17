using System;
using Accounts.Dto.Interfaces;

namespace Accounts.Business.Services.Interfaces
{
    /// <summary>
    /// Base interface for CRUD service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IService<T> where T : IMappedDto
    {
        /// Read items
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAsync();

        /// <summary>
        /// Read item by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// Create item and return created item
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<T> CreateAsync(T dto);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="dto"></param>
        Task UpdateAsync(T dto);

        /// <summary>
        /// Delete item by identifier
        /// </summary>
        /// <param name="id"></param>
        Task DeleteAsync(int id);
    }
}
