using CorePush.Google;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace PureNotificationSystem.Common.PushProvider
{
    public static class Extensions
    {
        public static void AddPushProvider(this ServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FirebaseOptions>(configuration.GetSection("firebase"));
            services.AddSingleton(c =>
            {
                var options = c.GetService<IOptions<FirebaseOptions>>();
                return new FcmSender(options.Value.ServerKey, options.Value.SenderId);
            });
        }
    }
}
