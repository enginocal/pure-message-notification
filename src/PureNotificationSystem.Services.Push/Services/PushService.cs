using CorePush.Google;
using PureNotificationSystem.Common.Exceptions;
using PureNotificationSystem.Services.Push.Domains.Models;
using PureNotificationSystem.Services.Push.Domains.Repositories;
using System;
using System.Threading.Tasks;

namespace PureNotificationSystem.Services.Push.Services
{
    public class PushService : IPushService
    {
        private readonly IPushRepository _repository;

        public PushService(IPushRepository repository)
        {
            _repository = repository;
        }

        public async Task SendAsync(Guid messageId, string textMessage, string deviceToken, DateTime createdAt)
        {
            if (string.IsNullOrEmpty(textMessage) || string.IsNullOrEmpty(deviceToken))
            {
                throw new PureNotificationException("Text message or device token can not be null.");
            }

            var message = new PushMessage(messageId, textMessage, deviceToken, createdAt);
            await _repository.AddAsync(message);


            var res = await SendToPushProvider(message);

        }

        private async Task<FcmResponse> SendToPushProvider(PushMessage message)
        {
            var fcm = new FcmSender("AAAAKquFIcw:APA91bGOmzRaHrhrJamb70K29-ecgflt8OZTYdQs8cSvB8kAYZME9TdeJlWDuYuEgXV7mF3fWyNVRka91so8ua-yzOgnVWNi7KuB-Ib8xSLQ_0MxzsL5QB5jxqOcme8Y8_NbDgcbnSUb", "183266255308");
            var res = await fcm.SendAsync(message.DeviceToken,
                                           new
                                           {
                                               notification = new
                                               {
                                                   body = message.TextMessage
                                               },
                                           });
            return res;
        }
    }
}
