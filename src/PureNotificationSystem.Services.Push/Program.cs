using PureNotificationSystem.Common.Commands;
using PureNotificationSystem.Common.Services;

namespace PureNotificationSystem.Services.Push
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<CreatePushMessage>()
                .Build()
                .Run();
        }
    }
}
