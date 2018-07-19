using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.DI
{
    public interface IContainerBuilder
    {
        IContainerBuilder Add(
            Type serviceType,
            Type implementationType,
            ServiceLifetime lifetime);
        IContainerBuilder Add<TService>(TService instance)
            where TService : class;

        IContainerBuilder Add<TService>(
            Func<IServiceProvider, TService> factory,
            ServiceLifetime lifetime)
            where TService : class;

        bool IsRegistered(Type serviceType);

        IServiceProvider Build();
    }
}
