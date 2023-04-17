using System;
using Accounts.DAL.Repositories.Interfaces;
using Accounts.Dto;
using Accounts.Entities;
using AutoMapper;

namespace Accounts.DAL.Repositories
{
    public class PositionRepository : GenericRepository<PositionDto, Position>, IPositionRepository
    {
        public PositionRepository(AccountsDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
