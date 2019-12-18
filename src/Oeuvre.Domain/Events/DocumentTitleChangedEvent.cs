using System;

namespace Oeuvre.Domain.Events {
    public class DocumentTitleChangedEvent : DomainEvent {
        public DocumentTitleChangedEvent(string title, DateTimeOffset modifiedAt) {
            Title = title;
            ModifiedAt = modifiedAt;
        }

        public string Title { get; }
        public DateTimeOffset ModifiedAt { get; }
    }
}