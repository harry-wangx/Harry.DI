#if COREFX
using System;
using System.Collections.Generic;
using System.Text;
using Harry.DI;

namespace Microsoft.Extensions.DependencyInjection
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