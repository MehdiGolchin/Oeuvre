using System;
using System.Threading.Tasks;

namespace Oeuvre.Functions {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="parameterType"></param>
    public delegate object FunctionParameterResolver(Type parameterType);

    /// <summary>
    /// 
    /// </summary>
    public class FunctionInvoker : IFunctionInvoker {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public FunctionInvoker(IServiceProvider serviceProvider) {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        /// <summary>
        /// 
        /// </summary>
        public IServiceProvider ServiceProvider { get; }

        /// <inheritdoc />
        public Task InvokeAsync<TFunc>(TFunc function) where TFunc : IFunction {
            var functionHandler = (IFunctionHandler<TFunc>)ServiceProvider.GetService(typeof(IFunctionHandler<TFunc>));
            return functionHandler.ExecuteAsync(function);
        }
    }
}