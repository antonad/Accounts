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
        private readonly IEmployeeServiceProxy _employeeServiceProxy;

        public EmployeesController(IEmployeeServiceProxy employeeServiceProxy)
        {
            _employeeServiceProxy = employeeServiceProxy;
        }


        /// <summary>
        /// Get all employees
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<EmployeeModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetEmployees()
        {
            return Ok(await _employeeServiceProxy.GetEmployeeAsync());
        }

        /// <summary>
        ///  Get employee by Id
        /// </summary>
        /// <param name="id"> Employee Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetEmployee(int id)
        {
            return Ok(await _employeeServiceProxy.GetEmployeeAsync(id));
        }

        /// <summary>
        /// Create new employee
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(EmployeeModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] EmployeeModel model)
        {
            return Ok(await _employeeServiceProxy.CreateEmployeeAsync(model));
        }

        /// <summary>
        /// Update employee
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] EmployeeModel model)
        {
            await _employeeServiceProxy.UpdateEmployeeAsync(model);
            return Ok();
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="id"> Employee Id</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeServiceProxy.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}