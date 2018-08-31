using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if DI
using Microsoft.Extensions.DependencyInjection;
#else
using Autofac;
using Autofac.Builder;
#endif

namespace Harry.DI
{
    public class ContainerBuilder : IContainerBuilder
    {
#if DI
        private readonly IServiceCollection serviceCollection;
        public ContainerBuilder() : this(new ServiceCollection()) { }

        public ContainerBuilder(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
        }
#else
        private readonly Autofac.ContainerBuilder builder = null;
        private readonly List<Type> lstRegistered;

        public ContainerBuilder() : this(new Autofac.ContainerBuilder()) { }
        public ContainerBuilder(Autofac.ContainerBuilder builder)
        {
            this.builder = builder ?? throw new ArgumentNullException(nameof(builder));
            lstRegistered = new List<Type>();
            builder.RegisterType<AutofacServiceProvider>().As<IServiceProvider>();
        }

#endif
        public IContainerBuilder Add(
            Type serviceType,
            Type implementationType,
            ServiceLifetime lifetime)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if (implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

#if DI
            serviceCollection.Add(new ServiceDescriptor(serviceType, implementationType, GetMSServiceLifetime(lifetime)));
#else
            if (serviceType.IsGenericTypeDefinition)
            {
                builder
                    .RegisterGeneric(implementationType)
                    .As(serviceType)
                    .SetLifetime(lifetime);
            }
            else
            {
                builder
                    .RegisterType(implementationType)
                    .As(serviceType)
                    .SetLifetime(lifetime);
            }
            lstRegistered.Add(serviceType);
#endif
            return this;
        }
        public IContainerBuilder Add<TService>(TService instance)
            where TService : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

#if DI
            serviceCollection.Add(new ServiceDescriptor(typeof(TService), instance));
#else
            builder.RegisterInstance(instance).As(typeof(TService)).SetLifetime(ServiceLifetime.Singleton);
            lstRegistered.Add(typeof(TService));
#endif
            return this;
        }
        public IContainerBuilder Add<TService>(
            Func<IServiceProvider, TService> factory,
            ServiceLifetime lifetime)
            where TService : class
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

#if DI
            serviceCollection.Add(new ServiceDescriptor(typeof(TService), factory, GetMSServiceLifetime(lifetime)));
#else
            var registration = RegistrationBuilder.ForDelegate(typeof(TService), (context, parameters) =>
            {
                var serviceProvider = context.Resolve<IServiceProvider>();
                return factory(serviceProvider);
            })
            .SetLifetime(lifetime)
            .CreateRegistration();

            builder.RegisterComponent(registration);
            lstRegistered.Add(typeof(TService));
#endif
            return this;
        }

        public bool IsRegistered(Type serviceType)
        {
#if DI
            return serviceCollection.Any(m => m.ServiceType == serviceType);
#else
            return lstRegistered.Any(m => m == serviceType);
#endif
        }

        public IServiceProvider Build()
        {
#if DI
            return serviceCollection.BuildServiceProvider();
#else
            var container = builder.Build();
            return new AutofacServiceProvider(container);
#endif
        }


#if DI
        private Microsoft.Extensions.DependencyInjection.ServiceLifetime GetMSServiceLifetime(ServiceLifetime lifetime)
        {
            switch (lifetime)
            {
                case ServiceLifetime.Singleton:
                    return Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton;
                case ServiceLifetime.Scoped:
                    return Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped;
                default:
                    return Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient;
            }
        }
#endif
    }
}
