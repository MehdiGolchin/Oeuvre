using System.Threading.Tasks;

namespace Oeuvre.Functions {
    /// <summary>
    /// 
    /// </summary>
    public interface IFunctionInvoker {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        Task InvokeAsync<TFunc>(TFunc function) where TFunc : IFunction;
    }
}