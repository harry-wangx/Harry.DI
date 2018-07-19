#if !COREFX
using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Harry.DI
{
    /// <summary>
    /// <see cref="IServiceProvider"/> 的 Autofac 实现.
    /// </summary>
    /// <seealso cref="System.IServiceProvider" />
    public class AutofacServiceProvider : IServiceProvider
    {
        private readonly IComponentContext _componentContext;

        public AutofacServiceProvider(IComponentContext componentContext)
        {
            this._componentContext = componentContext ?? throw new ArgumentNullException(nameof(componentContext));
        }

        public object GetService(Type serviceType)
        {
            //return this._componentContext.Resolve(serviceType);
            return this._componentContext.ResolveOptional(serviceType);
        }
    }
}

#endif
