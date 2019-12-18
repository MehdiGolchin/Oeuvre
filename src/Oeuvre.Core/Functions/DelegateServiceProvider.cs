using System;

namespace Oeuvre.Functions {
    /// <summary>
    /// 
    /// </summary>
    public class DelegateServiceProvider : IServiceProvider {
        private readonly Func<Type, object> _resolve;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resolve"></param>
        public DelegateServiceProvider(Func<Type, object> resolve) {
            _resolve = resolve ?? throw new ArgumentNullException(nameof(resolve));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType) =>
            _resolve(serviceType);
    }
}