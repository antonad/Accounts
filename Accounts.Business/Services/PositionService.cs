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
    }
}
