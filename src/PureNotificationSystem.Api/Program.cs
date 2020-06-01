using PureNotificationSystem.Common.Services;

namespace PureNotificationSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                //.SubscribeToEvent<PushMessageCreated>()
                //.SubscribeToEvent<CreateActivityRejected>()
                .Build()
                .Run();
        }
    }
}
