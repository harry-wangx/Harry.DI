using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.DI
{
    public static class ContainerBuilderExtensions
    {
        public static IContainerBuilder AddSingleton(this IContainerBuilder builder,
            Type serviceType, Type implementationType)
        {
            builder.Add(serviceType, implementationType, ServiceLifetime.Singleton);
            return builder;
        }

        public static IContainerBuilder AddScoped(this IContainerBuilder builder,
            Type serviceType, Type implementationType)
        {
            builder.Add(serviceType, implementationType, ServiceLifetime.Scoped);
            return builder;
        }

        public static IContainerBuilder AddTransient(this IContainerBuilder builder,
            Type serviceType, Type implementationType)
        {
            builder.Add(serviceType, implementationType, ServiceLifetime.Transient);
            return builder;
        }

        public static IContainerBuilder TryAdd(this IContainerBuilder builder,
             Type serviceType, Type implementationType, ServiceLifetime lifetime)
        {
            if (builder.IsRegistered(serviceType)) return builder;
            builder.Add(serviceType, implementationType, lifetime);
            return builder;
        }

        public static IContainerBuilder TryAddSingleton(this IContainerBuilder builder,
            Type serviceType, Type implementationType)
        {
            if (builder.IsRegistered(serviceType)) return builder;
            builder.Add(serviceType, implementationType, ServiceLifetime.Singleton);
            return builder;
        }

        public static IContainerBuilder TryAddScoped(this IContainerBuilder builder,
            Type serviceType, Type implementationType)
        {
            if (builder.IsRegistered(serviceType)) return builder;
            builder.Add(serviceType, implementationType, ServiceLifetime.Scoped);
            return builder;
        }

        public static IContainerBuilder TryAddTransient(this IContainerBuilder builder,
            Type serviceType, Type implementationType)
        {
            if (builder.IsRegistered(serviceType)) return builder;
            builder.Add(serviceType, implementationType, ServiceLifetime.Transient);
            return builder;
        }

        #region Add


        public static IContainerBuilder AddSingleton<TService, TImplementation>(this IContainerBuilder builder)
            where TImplementation : TService
        {
            return builder.Add(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton);
        }

        public static IContainerBuilder AddSingleton<TService>(this IContainerBuilder builder)
        {
            return builder.Add(typeof(TService), typeof(TService), ServiceLifetime.Singleton);
        }

        public static IContainerBuilder AddScoped<TService, TImplementation>(this IContainerBuilder builder)
            where TImplementation : TService
        {
            return builder.Add(typeof(TService), typeof(TImplementation), ServiceLifetime.Scoped);
        }

        public static IContainerBuilder AddScoped<TService>(this IContainerBuilder builder)
        {
            return builder.Add(typeof(TService), typeof(TService), ServiceLifetime.Scoped);
        }

        public static IContainerBuilder AddTransient<TService, TImplementation>(this IContainerBuilder builder)
            where TImplementation : TService
        {
            return builder.Add(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient);
        }

        public static IContainerBuilder AddTransient<TService>(this IContainerBuilder builder)
        {
            return builder.Add(typeof(TService), typeof(TService), ServiceLifetime.Transient);
        }

        public static IContainerBuilder TryAddSingleton<TService, TImplementation>(this IContainerBuilder builder)
            where TImplementation : TService
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(typeof(TService), typeof(TImplementation), ServiceLifetime.Singleton);
        }

        public static IContainerBuilder TryAddSingleton<TService>(this IContainerBuilder builder)
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(typeof(TService), typeof(TService), ServiceLifetime.Singleton);
        }

        public static IContainerBuilder TryAddScoped<TService, TImplementation>(this IContainerBuilder builder)
            where TImplementation : TService
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(typeof(TService), typeof(TImplementation), ServiceLifetime.Scoped);
        }

        public static IContainerBuilder TryAddScoped<TService>(this IContainerBuilder builder)
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(typeof(TService), typeof(TService), ServiceLifetime.Scoped);
        }

        public static IContainerBuilder TryAddTransient<TService, TImplementation>(this IContainerBuilder builder)
            where TImplementation : TService
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(typeof(TService), typeof(TImplementation), ServiceLifetime.Transient);
        }

        public static IContainerBuilder TryAddTransient<TService>(this IContainerBuilder builder)
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(typeof(TService), typeof(TService), ServiceLifetime.Transient);
        }
        #endregion

        #region Add Instance

        public static IContainerBuilder AddSingleton<TService>(this IContainerBuilder builder, TService instance)
            where TService : class
        {
            return builder.Add<TService>(instance);
        }

        public static IContainerBuilder TryAddSingleton<TService>(this IContainerBuilder builder, TService instance)
            where TService : class
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add<TService>(instance);
        }
        #endregion

        #region Add Func
        public static IContainerBuilder AddSingleton<TService>(this IContainerBuilder builder, Func<IServiceProvider, TService> factory)
            where TService : class
        {
            return builder.Add(factory, ServiceLifetime.Singleton);
        }

        public static IContainerBuilder AddScoped<TService>(this IContainerBuilder builder, Func<IServiceProvider, TService> factory)
            where TService : class
        {
            return builder.Add(factory, ServiceLifetime.Scoped);
        }


        public static IContainerBuilder AddTransient<TService>(this IContainerBuilder builder, Func<IServiceProvider, TService> factory)
            where TService : class
        {
            return builder.Add(factory, ServiceLifetime.Transient);
        }

        public static IContainerBuilder TryAddSingleton<TService>(this IContainerBuilder builder, Func<IServiceProvider, TService> factory)
            where TService : class
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(factory, ServiceLifetime.Singleton);
        }

        public static IContainerBuilder TryAddScoped<TService>(this IContainerBuilder builder, Func<IServiceProvider, TService> factory)
            where TService : class
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(factory, ServiceLifetime.Scoped);
        }


        public static IContainerBuilder TryAddTransient<TService>(this IContainerBuilder builder, Func<IServiceProvider, TService> factory)
            where TService : class
        {
            if (builder.IsRegistered(typeof(TService))) return builder;
            return builder.Add(factory, ServiceLifetime.Transient);
        }

        #endregion
    }
}
