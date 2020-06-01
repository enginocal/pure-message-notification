using System;

namespace PureNotificationSystem.Common.Commands
{
    public class CreatePushMessage : ICommand
    {
        public Guid MessageId { get; set; }

        public string TextMessage { get; set; }
        public string DeviceToken { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
