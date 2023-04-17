using System;
using Accounts.DAL.Repositories.Interfaces;
using Accounts.Dto;
using Accounts.Entities;
using AutoMapper;

namespace Accounts.DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<EmployeeDto, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AccountsDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
