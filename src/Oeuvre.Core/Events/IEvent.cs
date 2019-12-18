using System;

namespace Oeuvre.Events {
    public interface IEvent {
        Guid EventId { get; }
    }
}