using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.DI.Extensions
{
    public static class ServiceProviderServiceExtensions
    {
        /// <summary>
        /// 从容器中实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T GetService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return (T)provider.GetService(typeof(T));
        }

        /// <summary>
        /// 从容器中实例（如未注册，会抛出 InvalidOperationException 异常）
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var result = provider.GetService(serviceType);
            if (result == null)
                throw new InvalidOperationException($"获取类型{serviceType}实例出错，请确认已向容器注入此类型");
            return result;
        }

        /// <summary>
        /// 从容器中实例（如未注册，会抛出 InvalidOperationException 异常）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T GetRequiredService<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return (T)provider.GetRequiredService(typeof(T));
        }

        /// <summary>
        /// 从容器中实例的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            return provider.GetRequiredService<IEnumerable<T>>();
        }

        /// <summary>
        /// 从容器中实例的集合
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            if (serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }
    }
}
