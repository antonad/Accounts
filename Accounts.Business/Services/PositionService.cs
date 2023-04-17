using System;
using Accounts.Business.Services.Interfaces;
using Accounts.DAL;
using Accounts.Dto;
using Microsoft.Extensions.Logging;

namespace Accounts.Business.Services
{
    public class PositionService : GenericService<PositionDto>, IPositionService
    {
        public PositionService(IUnitOfWork unitOfWork, ILogger<PositionDto> logger) : 
            base(unitOfWork, unitOfWork.PositionRepository, logger)
        {
        }
        /// <inheritdoc />
        public override async Task DeleteAsync(int id)
        {
            try
            {
                PositionDto res = await _repository.ReadAsync(id);
                if (res == null)
                    throw new BusinessException("Not found");

                var employees = await _unitOfWork.EmployeeRepository.ReadEmployeesWithPositionAsync(id);
                if (employees.Any())
                    throw new BusinessException("Deleting of the position is denied. There are employees having the position.");

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
