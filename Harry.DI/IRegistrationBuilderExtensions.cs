#if !COREFX
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Builder;

namespace Harry.IoC
{
    public static class IRegistrationBuilderExtensions
    {
        public static IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> SetLifetime<TLimit, TActivatorData, TRegistrationStyle>(this IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> rb, ServiceLifetime serviceLifetime)
        {
            switch (serviceLifetime)
            {
                case ServiceLifetime.Singleton:
                    rb.SingleInstance();
                    break;
                case ServiceLifetime.Scoped:
                    rb.InstancePerLifetimeScope();
                    break;
                case ServiceLifetime.Transient:
                    rb.InstancePerDependency();
                    break;
            }
            return rb;
        }
    }
}
#endif