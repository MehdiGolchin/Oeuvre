using Oeuvre.Functions;

namespace Oeuvre.Services {
    /// <summary>
    /// 
    /// </summary>
    public class CreateDocumentFunction : IFunction {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IDocumentContent Content { get; set; }
    }
}