using System;
using Accounts.Business.Services.Interfaces;
using Accounts.DAL;
using Accounts.Dto;
using Microsoft.Extensions.Logging;

namespace Accounts.Business.Services
{
    public class EmployeeService : GenericService<EmployeeDto>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, ILogger<EmployeeDto> logger) : 
            base(unitOfWork, unitOfWork.EmployeeRepository, logger)
        {
        }
    }
}
