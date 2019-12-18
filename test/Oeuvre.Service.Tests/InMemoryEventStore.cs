using System.Threading.Tasks;
using Oeuvre.Collections;
using Oeuvre.Events;

namespace Oeuvre.Services.Tests {
    public class InMemoryEventStore : IEventStore {
        public Task StoreAsync(SinglyLinked<IEvent> events) {
            Events = events;
            return Task.CompletedTask;
        }

        public SinglyLinked<IEvent> Events { get; private set; }
    }
}