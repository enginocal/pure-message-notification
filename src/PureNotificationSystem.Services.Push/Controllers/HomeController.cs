using Microsoft.AspNetCore.Mvc;

namespace PureNotificationSystem.Services.Push.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get() => Content("Hello from PureNotificationSystem.Services.Push Api!");
    }
}
