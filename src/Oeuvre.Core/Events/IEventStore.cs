using System.Threading.Tasks;
using Oeuvre.Collections;

namespace Oeuvre.Events {
    public interface IEventStore {
        Task StoreAsync(SinglyLinked<IEvent> events);
    }
}