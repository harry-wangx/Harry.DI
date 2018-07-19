#if COREFX
using System;
using System.Collections.Generic;
using System.Text;
using Harry.DI;
using Microsoft.Extensions.DependencyInjection;

//这里使用 Harry.DI的命名空间，而不是微软DI的，因为其它自己写的库依赖于Harry.DI命名空间，早晚是要引用的
namespace Harry.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDI(this IServiceCollection services, Action<IContainerBuilder> containerBuilder)
        {
            services = services ?? throw new ArgumentNullException(nameof(services));
            ContainerBuilder builder = new ContainerBuilder(services);
            containerBuilder?.Invoke(builder);
            return services;
        }
    }
}

#endif