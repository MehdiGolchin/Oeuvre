using System;

namespace Oeuvre.Events {
    /// <summary>
    /// 
    /// </summary>
    public interface IEventHandler {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        void Emit(IEvent @event);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handler"></param>
        /// <typeparam name="T"></typeparam>
        IEventHandler On<T>(Action<T> handler) where T : IEvent;
    }
}