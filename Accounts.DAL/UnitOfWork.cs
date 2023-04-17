using System;
using Accounts.DAL.Repositories;
using Accounts.DAL.Repositories.Interfaces;
using Accounts.Dto;
using Accounts.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace Accounts.DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly AccountsDbContext _dbContext;
        private bool _error = false;
        private IMapper _mapper;

        public UnitOfWork(AccountsDbContext dbContext)
        {
            _dbContext = dbContext;
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Position, PositionDto>().ReverseMap().PreserveReferences();
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dest => dest.Positions, opt => opt.MapFrom(src => src.EmployeeToPostions.Select(x => x.Position)))
                    .PreserveReferences();
                cfg.CreateMap<EmployeeDto, Employee>()
                    .ForMember(dest => dest.EmployeeToPostions, opt => opt.MapFrom(src => src.Positions.Select(x =>
                        new EmployeeToPostion()
                        {
                            EmployeeId = src.Id,
                            PositionId = x.Id
                        }).ToList()))
                    .PreserveReferences();
            }
            ).CreateMapper();
        }

        private bool _disposed;

        private IEmployeeRepository _employeeRepository;
        public IEmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_dbContext, _mapper);

        private IPositionRepository _positionRepository;
        public IPositionRepository PositionRepository => _positionRepository ??= new PositionRepository(_dbContext, _mapper);

        public void SetError()
        {
            _error = true;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) _dbContext.Dispose();
            _disposed = true;
        }

        public async Task BeginTransactionAsync()
        {
            if (_dbContext.Database.CurrentTransaction == null)
            {
                await _dbContext.Database.BeginTransactionAsync();
                _error = false;
            }
        }

        public async Task EndTransactionAsync()
        {
            if (_dbContext.Database.CurrentTransaction != null)
            {
                if (_error)
                {
                    await _dbContext.Database.RollbackTransactionAsync();
                }
                else
                {
                    await _dbContext.Database.CommitTransactionAsync();
                }

                // Untrack all entites
                var entries =
                    _dbContext.ChangeTracker.Entries()
                        .Where(e =>
                            e.State == EntityState.Unchanged ||
                            e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                        .ToList();
                entries.ForEach(e => e.State = EntityState.Detached);
            }
        }
    }
}
