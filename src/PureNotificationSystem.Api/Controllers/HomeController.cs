using Microsoft.AspNetCore.Mvc;

namespace PureNotificationSystem.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Api is up.");
        }
    }
}
