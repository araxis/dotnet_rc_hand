using nanoFramework.DependencyInjection;
using RcHand.Application;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    public static class Module
    {
        public static IServiceCollection AddEsp32Hardware(this IServiceCollection services)
        {
           return services.AddSingleton(typeof(IConfigurationFactory),typeof(ConfigurationFactory))
                .AddSingleton(typeof(IServoMotorResolver),typeof(ServoMotorResolver))
                .AddSingleton(typeof(IJointController),typeof(JointController))
                .AddSingleton(typeof(IDelayHandler),typeof(DelayHandler));
        }
    }
}