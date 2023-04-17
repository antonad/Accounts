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
        public async Task<List<EmployeeModel>> GetEmployeeAsync()
        {
            return _mapper.Map<List<EmployeeModel>>(await _employeeService.GetAsync());
        }

        /// <inheritdoc />
        public async Task<EmployeeModel> GetEmployeeAsync(int id)
        {
            return _mapper.Map<EmployeeModel>(await _employeeService.GetAsync(id));
        }

        /// <inheritdoc />
        public async Task UpdateEmployeeAsync(EmployeeModel model)
        {
            await _employeeService.UpdateAsync(_mapper.Map<EmployeeDto>(model));
        }

        /// <inheritdoc />
        public async Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel model)
        {
            return _mapper.Map<EmployeeModel>(await _employeeService.CreateAsync(_mapper.Map<EmployeeDto>(model)));
        }

        /// <inheritdoc />
        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeService.DeleteAsync(id);
        }
    }
}
