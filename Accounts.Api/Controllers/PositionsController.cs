using Accounts.Api.Models;
using Accounts.Api.ServiceProxies.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionsController : ControllerBase
    {
        private readonly ILogger<PositionsController> _logger;
        private readonly IPositionServiceProxy _positionServiceProxy;

        public PositionsController(ILogger<PositionsController> logger, IPositionServiceProxy positionServiceProxy)
        {
            _logger = logger;
            _positionServiceProxy = positionServiceProxy;
        }

        /// <summary>
        /// Get all positions
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<PositionModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetPositions()
        {
            return Ok(await _positionServiceProxy.GetPositionAsync());
        }

        /// <summary>
        /// Get position by Id
        /// </summary>
        /// <param name="id">Position Id</param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PositionModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetPosition(int id)
        {
            return Ok(await _positionServiceProxy.GetPositionAsync(id));
        }
        
        /// <summary>
        /// Create new position
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(PositionModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Post([FromBody] PositionModel model)
        {
            return Ok(await _positionServiceProxy.CreatePositionAsync(model));
        }

        /// <summary>
        /// Update position
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PositionModel model)
        {
            await _positionServiceProxy.UpdatePositionAsync(model);
            return Ok();
        }

        /// <summary>
        /// Delete position
        /// </summary>
        /// <param name="id">Position Id</param>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _positionServiceProxy.DeletePositionAsync(id);
            return Ok();
        }
    }
}