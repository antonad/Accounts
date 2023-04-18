using Accounts.Api.Models;

namespace Accounts.Api.ServiceProxies.Interfaces
{
    public interface IEmployeeServiceProxy
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        Task<List<EmployeeViewModel>> GetEmployeeAsync();

        /// <summary>
        /// Get employee by Id
        /// </summary>
        /// <param name="id"> Requested employee Id</param>
        Task<EmployeeViewModel> GetEmployeeAsync(int id);

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="model">Employee model</param>
        Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeCreateModel model);

        /// <summary>
        /// Update existing employee
        /// </summary>
        /// <param name="model">Employee model</param>
        Task UpdateEmployeeAsync(EmployeeUpdateModel model);

        /// <summary>
        /// Delete employee by id
        /// </summary>
        /// <param name="id">Employee Id</param>
        Task DeleteEmployeeAsync(int id);
    }
}
