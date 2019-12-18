using System;
using System.Threading.Tasks;
using Oeuvre.Domain.Entities;
using Oeuvre.Events;
using Oeuvre.Functions;

namespace Oeuvre.Services {
    /// <summary>
    /// 
    /// </summary>
    public class CreateDocumentFunctionHandler : IFunctionHandler<CreateDocumentFunction> {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventStore"></param>
        public CreateDocumentFunctionHandler(IEventStore eventStore) {
            EventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        /// <summary>
        /// 
        /// </summary>
        protected IEventStore EventStore { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task ExecuteAsync(CreateDocumentFunction function) {
            var doc = Document.Create(function.Title);
            return EventStore.StoreAsync(doc.History);
        }
    }
}