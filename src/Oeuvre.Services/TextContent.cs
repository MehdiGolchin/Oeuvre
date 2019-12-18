namespace Oeuvre.Services {
    /// <summary>
    /// 
    /// </summary>
    public class TextContent : IDocumentContent {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public TextContent(string value) {
            Value = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }
}