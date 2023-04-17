using System;
using Accounts.Dto;
using Accounts.Entities;

namespace Accounts.DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository: IGenericRepository<EmployeeDto>
    {
        /// <summary>
        /// Read all employees with selected position
        /// </summary>
        /// <param name="positionId">Position Id</param>
        Task<IEnumerable<EmployeeDto>> ReadEmployeesWithPositionAsync(int positionId);
    }
}
