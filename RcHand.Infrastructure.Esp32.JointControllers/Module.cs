using nanoFramework.DependencyInjection;
using RcHand.Application;
using RcHand.Infrastructure.Esp32.JointControllers.Fingers;

namespace RcHand.Infrastructure.Esp32.JointControllers
{
    public static class Module
    {
        public static IServiceCollection AddThumbFinger(this IServiceCollection services,IServoConfiguration configuration)
        {
            services.AddSingleton(typeof(IThumbFinger),new ThumbFinger(configuration));
            return services;
        }
        public static IServiceCollection AddIndexFinger(this IServiceCollection services,IServoConfiguration configuration)
        {
            services.AddSingleton(typeof(IIndexFinger),new IndexFinger(configuration));
            return services;
        }
        public static IServiceCollection AddMiddleFinger(this IServiceCollection services,IServoConfiguration configuration)
        {
            services.AddSingleton(typeof(IMiddleFinger),new MiddleFinger(configuration));
            return services;
        }
        public static IServiceCollection AddRingFinger(this IServiceCollection services,IServoConfiguration configuration)
        {
            services.AddSingleton(typeof(IRingFinger),new RingFinger(configuration));
            return services;
        }
        public static IServiceCollection AddLittleFinger(this IServiceCollection services,IServoConfiguration configuration)
        {
            services.AddSingleton(typeof(ILittleFinger),new LittleFinger(configuration));
            return services;
        }
    }
}