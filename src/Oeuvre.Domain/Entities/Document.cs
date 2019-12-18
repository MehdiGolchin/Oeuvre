using System;
using System.Collections.Generic;
using Oeuvre.Collections;
using Oeuvre.Domain.Events;
using Oeuvre.Domain.ValueObjects;
using Oeuvre.Events;
using EventHandler = Oeuvre.Events.EventHandler;

namespace Oeuvre.Domain.Entities {
    /// <summary>
    /// Represents a document object.
    /// </summary>
    public class Document : IAggregateRoot {
        /// <summary>
        /// Creates an empty instance of <see cref="Document"/>.
        /// </summary>
        private Document() {
            Events = new EventHandler()
                .On<DocumentCreatedEvent>(OnDocumentCreatedEvent)
                .On<DocumentTitleChangedEvent>(OnDocumentTitleChangedEvent);
        }

        /// <summary>
        /// Gets the document identity.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the title of document.
        /// </summary>
        public string Title { get; private set; }
        
        /// <summary>
        /// 
        /// </summary>
        public IDocumentContent Content { get; private set; }

        /// <summary>
        /// Gets the creation date/time.
        /// </summary>
        public DateTimeOffset CreatedAt { get; private set; }

        /// <summary>
        /// Gets the last modification date/time.
        /// </summary>
        public DateTimeOffset ModifiedAt { get; private set; }

        /// <inheritdoc />
        public IEventHandler Events { get; }

        /// <inheritdoc />
        public SinglyLinked<IEvent> History { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="Document"/>.
        /// </summary>
        /// <param name="title">The title of document.</param>
        /// <returns>An instance of <see cref="Document"/>.</returns>
        public static Document Create() =>
            new Document().PushEvent(
                new DocumentCreatedEvent(Guid.NewGuid(), title, DateTimeOffset.UtcNow)
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public static Document LoadFrom(IEnumerable<IEvent> events) {
            var doc = new Document();
            foreach (var @event in events) {
                doc.PushEvent(@event);
            }

            return doc;
        }

        /// <summary>
        /// Changes the title of document.
        /// </summary>
        /// <param name="title">The new title.</param>
        /// <returns>An instance of <see cref="Document"/>.</returns>
        public void ChangeTitle(string title) =>
            PushEvent(
                new DocumentTitleChangedEvent(title, DateTimeOffset.UtcNow)
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        protected virtual void OnDocumentTitleChangedEvent(DocumentTitleChangedEvent @event) {
            Title = @event.Title;
            ModifiedAt = @event.ModifiedAt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        protected virtual void OnDocumentCreatedEvent(DocumentCreatedEvent @event) {
            Id = @event.DocumentId;
            Title = @event.Title;
            CreatedAt = @event.CreatedAt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        protected virtual Document PushEvent<TEvent>(TEvent @event) where TEvent : IEvent {
            Events.Emit(@event);
            History = History.Push(@event);
            return this;
        }
    }
}