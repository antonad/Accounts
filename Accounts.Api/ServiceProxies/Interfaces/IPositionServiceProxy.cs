using Accounts.Api.Models;

namespace Accounts.Api.ServiceProxies.Interfaces
{
    public interface IPositionServiceProxy
    {
        /// <summary>
        /// Get all positions
        /// </summary>
        Task<List<PositionViewModel>> GetPositionAsync();

        /// <summary>
        /// Get position by Id
        /// </summary>
        /// <param name="id"> Requested position Id</param>
        Task<PositionViewModel> GetPositionAsync(int id);

        /// <summary>
        /// Create new position
        /// </summary>
        /// <param name="model">Position model</param>
        Task<PositionViewModel> CreatePositionAsync(PositionCreateModel model);

        /// <summary>
        /// Update existing position
        /// </summary>
        /// <param name="model">Position model</param>
        Task UpdatePositionAsync(PositionUpdateModel model);

        /// <summary>
        /// Delete position by id
        /// </summary>
        /// <param name="id">Position Id</param>
        Task DeletePositionAsync(int id);
    }
}
