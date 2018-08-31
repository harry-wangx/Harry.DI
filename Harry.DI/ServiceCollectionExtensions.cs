#if DI
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
        /// <summary>
        /// 添加自定义DI库
        /// </summary>
        /// <param name="services"></param>
        /// <param name="containerBuilder"></param>
        /// <returns></returns>
        public static IServiceCollection AddDI(this IServiceCollection services, Action<IContainerBuilder> containerBuilder)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            ContainerBuilder builder = new ContainerBuilder(services);
            containerBuilder?.Invoke(builder);
            return services;
        }

        /// <summary>
        /// 添加自定义DI库
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IContainerBuilder AddDI(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            return new ContainerBuilder(services);
        }
    }
}

#endif