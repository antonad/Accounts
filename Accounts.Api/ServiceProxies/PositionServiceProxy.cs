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

        public async Task<List<PositionModel>> GetPositionAsync()
        {
            return _mapper.Map<List<PositionModel>>(await _positionService.GetAsync());
        }
        public async Task<PositionModel> GetPositionAsync(int id)
        {
            return _mapper.Map<PositionModel>(await _positionService.GetAsync(id));
        }

        public async Task UpdatePositionAsync(PositionModel model)
        {
            await _positionService.UpdateAsync(_mapper.Map<PositionDto>(model));
        }
        public async Task<PositionModel> CreatePositionAsync(PositionModel model)
        {
            return _mapper.Map<PositionModel>(await _positionService.CreateAsync(_mapper.Map<PositionDto>(model)));
        }

        public async Task DeletePositionAsync(int id)
        {
            await _positionService.DeleteAsync(id);
        }
    }
}
