using Accounts.Api.Models;
using Accounts.Api.ServiceProxies.Interfaces;
using Accounts.Business.Services.Interfaces;
using Accounts.Dto;
using AutoMapper;

namespace Accounts.Api.ServiceProxies
{
    public class EmployeeServiceProxy : IEmployeeServiceProxy
    {
        IEmployeeService _employeeService;
        IMapper _mapper;

        public EmployeeServiceProxy(IEmployeeService employeeService, IMapper mapper) 
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<List<EmployeeViewModel>> GetEmployeeAsync()
        {
            return _mapper.Map<List<EmployeeViewModel>>(await _employeeService.GetAsync());
        }

        /// <inheritdoc />
        public async Task<EmployeeViewModel> GetEmployeeAsync(int id)
        {
            return _mapper.Map<EmployeeViewModel>(await _employeeService.GetAsync(id));
        }

        /// <inheritdoc />
        public async Task UpdateEmployeeAsync(EmployeeUpdateModel model)
        {
            await _employeeService.UpdateAsync(_mapper.Map<EmployeeDto>(model));
        }

        /// <inheritdoc />
        public async Task<EmployeeViewModel> CreateEmployeeAsync(EmployeeCreateModel model)
        {
            return _mapper.Map<EmployeeViewModel>(await _employeeService.CreateAsync(_mapper.Map<EmployeeDto>(model)));
        }

        /// <inheritdoc />
        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeService.DeleteAsync(id);
        }
    }
}
