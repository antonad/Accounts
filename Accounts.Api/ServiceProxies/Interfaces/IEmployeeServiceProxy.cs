using Accounts.Api.Models;

namespace Accounts.Api.ServiceProxies.Interfaces
{
    public interface IEmployeeServiceProxy
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        Task<List<EmployeeModel>> GetEmployeeAsync();

        /// <summary>
        /// Get employee by Id
        /// </summary>
        /// <param name="id"> Requested employee Id</param>
        Task<EmployeeModel> GetEmployeeAsync(int id);

        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="model">Employee model</param>
        Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel model);

        /// <summary>
        /// Update existing employee
        /// </summary>
        /// <param name="model">Employee model</param>
        Task UpdateEmployeeAsync(EmployeeModel model);

        /// <summary>
        /// Delete employee by id
        /// </summary>
        /// <param name="id">Employee Id</param>
        Task DeleteEmployeeAsync(int id);
    }
}
