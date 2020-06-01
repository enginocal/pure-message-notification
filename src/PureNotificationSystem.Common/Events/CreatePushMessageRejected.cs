using System;

namespace PureNotificationSystem.Common.Events
{
    public class CreatePushMessageRejected : IRejectedEvent
    {
        public Guid Id { get; set; }
        public string DeviceToken { get; set; }
        public string Reason { get; }

        public string Code { get; }

        protected CreatePushMessageRejected()
        {
        }

        public CreatePushMessageRejected(Guid id,string deviceToken,string reason,string code)
        {
            Id = id;
            DeviceToken = deviceToken;
            Reason = reason;
            Code = code;
        }

    }
}
