using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Domain.Events {
    public class DocumentCreatedEvent : DomainEvent {
        public DocumentCreatedEvent(Guid documentId, string title, DateTimeOffset createdAt) {
            DocumentId = documentId;
            Title = title;
            CreatedAt = createdAt;
        }
        
        public Guid DocumentId { get; }
        public string Title { get; }
        public DateTimeOffset CreatedAt { get; }
    }
}