using Accounts.Api.Models;
using Accounts.Api.ServiceProxies.Interfaces;
using Accounts.Business.Services.Interfaces;
using Accounts.Dto;
using AutoMapper;

namespace Accounts.Api.ServiceProxies
{
    public class PositionServiceProxy : IPositionServiceProxy
    {
        IPositionService _positionService;
        IMapper _mapper;

        public PositionServiceProxy(IPositionService positionService, IMapper mapper) 
        {
            _positionService = positionService;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<List<PositionViewModel>> GetPositionAsync()
        {
            return _mapper.Map<List<PositionViewModel>>(await _positionService.GetAsync());
        }

        /// <inheritdoc />
        public async Task<PositionViewModel> GetPositionAsync(int id)
        {
            return _mapper.Map<PositionViewModel>(await _positionService.GetAsync(id));
        }

        /// <inheritdoc />
        public async Task UpdatePositionAsync(PositionUpdateModel model)
        {
            await _positionService.UpdateAsync(_mapper.Map<PositionDto>(model));
        }

        /// <inheritdoc />
        public async Task<PositionViewModel> CreatePositionAsync(PositionCreateModel model)
        {
            return _mapper.Map<PositionViewModel>(await _positionService.CreateAsync(_mapper.Map<PositionDto>(model)));
        }

        /// <inheritdoc />
        public async Task DeletePositionAsync(int id)
        {
            await _positionService.DeleteAsync(id);
        }
    }
}
