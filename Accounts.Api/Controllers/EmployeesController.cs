using Accounts.Api.Models;
using Accounts.Api.ServiceProxies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeServiceProxy _employeeServiceProxy;

        public EmployeesController(ILogger<EmployeesController> logger, IEmployeeServiceProxy employeeServiceProxy)
        {
            _logger = logger;
            _employeeServiceProxy = employeeServiceProxy;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EmployeeModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetEmployees()
        {
            return Ok(await _employeeServiceProxy.GetEmployeeAsync());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetEmployee(int id)
        {
            return Ok(await _employeeServiceProxy.GetEmployeeAsync(id));
        }
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] EmployeeModel model)
        {
            return Ok(await _employeeServiceProxy.CreateEmployeeAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EmployeeModel model)
        {
            await _employeeServiceProxy.UpdateEmployeeAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeServiceProxy.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}