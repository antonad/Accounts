using System;
using Accounts.Dto.Interfaces;

namespace Accounts.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : IMappedDto
    {
        /// <summary>
        /// Read all elements from database
        /// </summary>
        Task<IEnumerable<T>> ReadAsync();

        /// <summary>
        /// Read one elements from database
        /// </summary>
        /// <param name="id">Id of the element</param>
        Task<T> ReadAsync(int id);

        /// <summary>
        /// Create element in database
        /// </summary>
        /// <param name="dto">Element dto</param>
        Task<T> CreateAsync(T dto);

        /// <summary>
        /// Update element in database
        /// </summary>
        /// <param name="dto">Update dto</param>
        Task UpdateAsync(T dto);

        /// <summary>
        /// Delete element in database
        /// </summary>
        /// <param name="id">Element id</param>
        Task DeleteAsync(int id);
    }
}
