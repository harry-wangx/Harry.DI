using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.DI
{
    public interface IContainerBuilder
    {
        /// <summary>
        /// 向容注册类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <param name="implementationType">实现类型</param>
        /// <param name="lifetime">生命周期</param>
        /// <returns></returns>
        IContainerBuilder Add(
            Type serviceType,
            Type implementationType,
            ServiceLifetime lifetime);

        /// <summary>
        /// 向容注册类型（单例模式）
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="instance">实例</param>
        /// <returns></returns>
        IContainerBuilder Add<TService>(TService instance)
            where TService : class;

        /// <summary>
        /// 向容注册类型
        /// </summary>
        /// <typeparam name="TService">服务类型</typeparam>
        /// <param name="factory">服务类型实例生成函数</param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        IContainerBuilder Add<TService>(
            Func<IServiceProvider, TService> factory,
            ServiceLifetime lifetime)
            where TService : class;

        /// <summary>
        /// 容器内是否已注册当前服务类型
        /// </summary>
        /// <param name="serviceType">服务类型</param>
        /// <returns></returns>
        bool IsRegistered(Type serviceType);

        /// <summary>
        /// 构建 IServiceProvider实例
        /// </summary>
        /// <returns></returns>
        IServiceProvider Build();
    }
}
