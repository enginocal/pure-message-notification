using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PureNotificationSystem.Api.Repositories;
using PureNotificationSystem.Common.Commands;
using RawRabbit;

namespace PureNotificationSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushMessageController : ControllerBase
    {
        private readonly IBusClient _busClient;
        private readonly IPushRepository _pushRepository;

        public PushMessageController(IBusClient busClient, IPushRepository pushRepository)
        {
            _busClient = busClient;
            _pushRepository = pushRepository;
        }

        [HttpGet("{deviceToken}")]
        public async Task<IActionResult> Get( string deviceToken)
        {
            var messages = await _pushRepository.BrowseAsync(deviceToken);
            if (messages == null)
            {
                return NotFound();
            }

            return Ok(messages);
        }

        [HttpPost("")]
        public async Task<IActionResult> Post([FromBody] CreatePushMessage command)
        {
            command.MessageId = Guid.NewGuid();
            command.CreatedAt = DateTime.UtcNow;
            await _busClient.PublishAsync(command);

            return Accepted($"pushmessages/{command.MessageId}");
        }



    }
}
