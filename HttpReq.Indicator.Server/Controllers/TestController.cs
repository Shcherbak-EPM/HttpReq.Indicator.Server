using Microsoft.AspNetCore.Mvc;

namespace HttpReq.Indicator.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("error")]
        public IActionResult GetError()
        {

            throw new InvalidOperationException("This is a test exception");
        }

        [HttpGet("validation-error")]
        public IActionResult GetValidationError()
        {
            throw new ArgumentException("This is a validation error");
        }
    }
}
