using Accounts.Api.Models;

namespace Accounts.Api.ServiceProxies.Interfaces
{
    public interface IPositionServiceProxy
    {
        /// <summary>
        /// Get all positions
        /// </summary>
        Task<List<PositionModel>> GetPositionAsync();

        /// <summary>
        /// Get position by Id
        /// </summary>
        /// <param name="id"> Requested position Id</param>
        Task<PositionModel> GetPositionAsync(int id);

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="model">Position model</param>
        Task<PositionModel> CreatePositionAsync(PositionModel model);

        /// <summary>
        /// Update existing position
        /// </summary>
        /// <param name="model">Position model</param>
        Task UpdatePositionAsync(PositionModel model);

        /// <summary>
        /// Delete position by id
        /// </summary>
        /// <param name="id">Position Id</param>
        Task DeletePositionAsync(int id);
    }
}
