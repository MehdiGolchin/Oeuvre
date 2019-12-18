using System.Threading.Tasks;

namespace Oeuvre.Functions {
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TFunc"></typeparam>
    public interface IFunctionHandler<in TFunc> where TFunc : IFunction {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        Task ExecuteAsync(TFunc function);
    }
}