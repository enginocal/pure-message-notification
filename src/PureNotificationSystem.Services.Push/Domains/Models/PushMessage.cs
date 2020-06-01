using System;

namespace PureNotificationSystem.Services.Push.Domains.Models
{
    public class PushMessage
    {
        public Guid MessageId { get; set; }

        public string TextMessage { get; set; }
        public string DeviceToken { get; set; }
        public DateTime CreatedAt { get; set; }

        protected PushMessage()
        {
        }

        public PushMessage(Guid messageId, string textMessage, string deviceToken, DateTime createdAt)
        {
            MessageId = messageId;
            TextMessage = textMessage;
            DeviceToken = deviceToken;
            CreatedAt = createdAt;
        }

    }
}
