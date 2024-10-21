using HttpReq.Indicator.Server.Models;
using HttpReq.Indicator.Server.Utils;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HttpReq.Indicator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpReqController : ControllerBase
    {
        [HttpGet("get")]
        public IActionResult Get([FromQuery] RequestModel request)
        {
            var serverReceivedTime = DateTime.UtcNow;
            string errorMessage = string.Empty; // Initialize the errorMessage variable

            // Validate the request
            if (request == null || !RequestUtils.ValidateRequest(request.Data, out errorMessage))
            {
                return BadRequest(new
                {
                    message = errorMessage,
                    serverReceivedTime = serverReceivedTime.ToString("o") // ISO 8601 format
                });
            }

            // Create and return the response using utility method
            var response = RequestUtils.CreateResponse("GET", request.Data, serverReceivedTime);
            return Ok(response);
        }

        [HttpPost("post")]
        public IActionResult Post([FromBody] RequestModel request)
        {
            var serverReceivedTime = DateTime.UtcNow;
            string errorMessage = string.Empty; // Initialize the errorMessage variable

            // Validate the request
            if (request == null || !RequestUtils.ValidateRequest(request.Data, out errorMessage))
            {
                return BadRequest(new
                {
                    message = errorMessage,
                    serverReceivedTime = serverReceivedTime.ToString("o")
                });
            }

            // Create and return the response using utility method
            var response = RequestUtils.CreateResponse("POST", request.Data, serverReceivedTime);
            return Ok(response);
        }
    }
}
