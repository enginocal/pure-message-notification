using MongoDB.Bson.Serialization.Attributes;
using System;

namespace PureNotificationSystem.Api.Models
{
    [BsonIgnoreExtraElements]
    public class PushMessage
    {
        public string TextMessage { get; set; }
        public string DeviceToken { get; set; }
        public Guid MessageId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
