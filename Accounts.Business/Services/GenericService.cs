using System;
using Accounts.Dto.Interfaces;
using Accounts.Business.Services.Interfaces;
using System.Threading.Tasks;
using Accounts.DAL;
using Accounts.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace Accounts.Business.Services
{
    /// <summary>
    /// Common class for CRUD operations for single Dto.
    /// </summary>
    /// <typeparam name="T">Dto class</typeparam>
    public abstract class GenericService<T>: IService<T> where T : class, IMappedDto
    {
        /// <summary>
        /// Implementation of Unit of Work.
        /// </summary>
        protected readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Repository for the Template Dto.
        /// </summary>
        protected IGenericRepository<T> _repository;

        /// <summary>
        /// Service name is used for logs.
        /// </summary>
        protected string _serviceName;

        /// <summary>
        /// Logger instance.
        /// </summary>
        protected ILogger _logger;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository, ILogger<T> logger)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _serviceName = GetType().Name;
            _logger = logger;
        }

        /// <inheritdoc />
        public virtual async Task<T> CreateAsync(T dto)
        {
            try
            {
                return await _repository.CreateAsync(dto);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, $"{_serviceName} CreateAsync error: {ex.Message}");
                _unitOfWork.SetError();
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task<List<T>> GetAsync()
        {
            try
            {
                return (await _repository.ReadAsync()).ToList();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, $"{_serviceName} GetAsync error: {ex.Message}");
                _unitOfWork.SetError();
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task<T> GetAsync(int id)
        {
            try
            {
                T res = await _repository.ReadAsync(id);
                if (res == null)
                    throw new BusinessException("Not found");

                return res;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, $"{_serviceName} CreateAsync error: {ex.Message}");
                _unitOfWork.SetError();
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task UpdateAsync(T dto)
        {
            try
            {
                await _repository.UpdateAsync(dto);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, $"{_serviceName} UpdateAsync error: {ex.Message}");
                _unitOfWork.SetError();
                throw;
            }
        }

        /// <inheritdoc />
        public virtual async Task DeleteAsync(int id)
        {
            try
            {
                T res = await _repository.ReadAsync(id);
                if (res == null)
                    throw new BusinessException("Not found");

                await _repository.DeleteAsync(id);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, $"{_serviceName} DeleteAsync error: {ex.Message}");
                _unitOfWork.SetError();
                throw;
            }
        }
    }
}
