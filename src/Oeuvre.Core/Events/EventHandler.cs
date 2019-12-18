using System;
using System.Collections.Immutable;

namespace Oeuvre.Events {
    /// <summary>
    /// 
    /// </summary>
    public sealed class EventHandler : IEventHandler {
        public EventHandler() : this(ImmutableDictionary.Create<Type, Action<IEvent>>()) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handlers"></param>
        public EventHandler(IImmutableDictionary<Type, Action<IEvent>> handlers) {
            Handlers = handlers ?? throw new ArgumentNullException(nameof(handlers));
        }

        /// <summary>
        /// 
        /// </summary>
        private IImmutableDictionary<Type, Action<IEvent>> Handlers { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        public void Emit(IEvent @event) =>
            Handlers[@event.GetType()](@event);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        public IEventHandler On<T>(Action<T> handler) where T : IEvent =>
            new EventHandler(Handlers.Add(typeof(T), @event => handler((T) @event)));
    }
}