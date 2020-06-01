using System;

namespace PureNotificationSystem.Common.Events
{
    public class PushMessageCreated : IEvent
    {
        public string TextMessage { get; set; }
        public string DeviceToken { get; set; }
        public Guid MessageId { get; set; }
        public DateTime CreatedAt { get; set; }

        public PushMessageCreated(string textMessage, string deviceToken, Guid messageId, DateTime createdAt)
        {
            TextMessage = textMessage;
            DeviceToken = deviceToken;
            MessageId = messageId;
            CreatedAt = createdAt;
        }
    }
}
