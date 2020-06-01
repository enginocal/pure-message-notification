using Microsoft.Extensions.Logging;
using PureNotificationSystem.Common.Commands;
using PureNotificationSystem.Common.Events;
using PureNotificationSystem.Common.Exceptions;
using PureNotificationSystem.Services.Push.Services;
using RawRabbit;
using System;
using System.Threading.Tasks;

namespace PureNotificationSystem.Services.Push.Handlers
{
    public class CreatePushMessageHandler : ICommandHandler<CreatePushMessage>
    {
        private readonly ILogger _logger;
        private readonly IBusClient _busClient;
        private readonly IPushService _pushService;

        public CreatePushMessageHandler(IBusClient busClient,
            IPushService pushService,
            ILogger<CreatePushMessageHandler> logger)
        {
            _busClient = busClient;
            _pushService = pushService;
            _logger = logger;
        }

        public async Task HandleAsync(CreatePushMessage command)
        {
            _logger.LogInformation($"Creating push message : '{command.MessageId}' ");
            try
            {
                await _pushService.SendAsync(command.MessageId, command.TextMessage, command.DeviceToken, command.CreatedAt);
                await _busClient.PublishAsync(new PushMessageCreated(command.TextMessage, command.DeviceToken, command.MessageId
                    , command.CreatedAt));
                _logger.LogInformation($"Push message: '{command.MessageId}' was created .");

                return;
            }
            catch (PureNotificationException ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreatePushMessageRejected(command.MessageId,
                    command.DeviceToken,
                    ex.Message, ex.Code));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _busClient.PublishAsync(new CreatePushMessageRejected(command.MessageId,
                    command.DeviceToken,
                    ex.Message, "error"));
            }
        }
    }
}
