using System;
using Oeuvre.Events;

namespace Oeuvre.Domain.Events {
    public abstract class DomainEvent : IEvent {
        protected DomainEvent() {
            EventId = Guid.NewGuid();
        }
        
        public Guid EventId { get; }
    }
}