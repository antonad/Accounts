using System;
using Accounts.DAL.Repositories.Interfaces;
using Accounts.Dto.Interfaces;
using Accounts.Entities.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Accounts.DAL.Repositories
{
    public class GenericRepository<TDto, TEntity> : IGenericRepository<TDto>
        where TDto : class, IMappedDto
        where TEntity : class, IEntity
    {
        protected readonly AccountsDbContext _dbContext;

        private bool _disposed;
        protected IMapper _mapper;

        public GenericRepository(AccountsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>Gets the base query. Can be overriden in inherited classes</summary>
        /// <returns>
        /// Base query for futher usages
        /// </returns>
        protected virtual IQueryable<TEntity> GetBaseQuery()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TDto>> ReadAsync()
        {
            return _mapper.Map<List<TEntity>, List<TDto>>(await GetBaseQuery().ToListAsync());
        }

        /// <inheritdoc />
        public virtual async Task<TDto> ReadAsync(int id)
        {
            return _mapper.Map<TDto>(await GetBaseQuery().SingleOrDefaultAsync(e => e.Id == id));
        }

        /// <inheritdoc />
        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var resultDto = _dbContext.Set<TEntity>().Add(_mapper.Map<TEntity>(dto));
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
            return await ReadAsync(resultDto.Entity.Id);
        }

        /// <inheritdoc />
        public virtual async Task UpdateAsync(TDto dto)
        {
            _dbContext.Set<TEntity>().Update(_mapper.Map<TEntity>(dto));
            await _dbContext.SaveChangesAsync();
            _dbContext.ChangeTracker.Clear();
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
            if (entity == null) return;
            _dbContext.Set<TEntity>().Remove(entity);
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
    }
}
