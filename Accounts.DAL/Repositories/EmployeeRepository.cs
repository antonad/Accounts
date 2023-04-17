using System;
using Accounts.DAL.Repositories.Interfaces;
using Accounts.Dto;
using Accounts.Entities;
using Accounts.Entities.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Accounts.DAL.Repositories
{
    public class EmployeeRepository: GenericRepository<EmployeeDto, Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AccountsDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        /// <inheritdoc />
        protected override IQueryable<Employee> GetBaseQuery()
        {
            return _dbContext.Set<Employee>()
                .AsNoTracking()
                .Include(e => e.EmployeeToPostions)
                .ThenInclude(e => e.Position);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<EmployeeDto>> ReadEmployeesWithPositionAsync(int positionId)
        {
            return _mapper.Map<List<Employee>, List<EmployeeDto>>(await GetBaseQuery()
                .Where(e => e.EmployeeToPostions.Where(ep => ep.PositionId == positionId).Any())
                .ToListAsync());
        }
        /// <inheritdoc />
        public override async Task UpdateAsync(EmployeeDto dto)
        {
            Employee emploee = _mapper.Map<Employee>(dto);

            var alreadyExisting = _dbContext.Set<EmployeeToPostion>().Where(e => e.EmployeeId == dto.Id);
            _dbContext.Set<EmployeeToPostion>().RemoveRange(alreadyExisting);

            _dbContext.Set<Employee>().Update(emploee);
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
        }
    }
}
