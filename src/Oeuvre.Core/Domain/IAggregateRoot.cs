using Oeuvre.Collections;
using Oeuvre.Events;

namespace Oeuvre.Domain {
    /// <summary>
    /// 
    /// </summary>
    public interface IAggregateRoot {
        /// <summary>
        /// Gets the <see cref="IEventHandler"/> instance.
        /// </summary>
        IEventHandler Events { get; }

        /// <summary>
        /// Gets a history of events that are happened.
        /// </summary>
        SinglyLinked<IEvent> History { get; }
    }
}