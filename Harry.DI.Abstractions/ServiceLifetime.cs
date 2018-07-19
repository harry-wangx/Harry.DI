using System;
using System.Collections.Generic;
using System.Text;

namespace Harry.IoC
{
    public enum ServiceLifetime
    {
        /// <summary>
        /// 将创建服务的单个实例
        /// </summary>
        Singleton,
        /// <summary>
        /// 将为每个作用域创建服务的新实例
        /// </summary>
        Scoped,
        /// <summary>
        /// 次请求时都会创建服务的新实例
        /// </summary>
        Transient
    }
}
