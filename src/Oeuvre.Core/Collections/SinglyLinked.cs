using System;
using System.Collections;
using System.Collections.Generic;

namespace Oeuvre.Collections {
    /// <summary>
    /// 
    /// </summary>
    public class SinglyLinked<T> : IEnumerable<T>, IEnumerable {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="head"></param>
        /// <param name="tail"></param>
        public SinglyLinked(T head, SinglyLinked<T> tail) {
            Head = head;
            Tail = tail;
        }

        /// <summary>
        /// 
        /// </summary>
        public T Head { get; }

        /// <summary>
        /// 
        /// </summary>
        public SinglyLinked<T> Tail { get; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLast => Tail == null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerator<T> GetEnumerator() {
            return new SinglyLinkedEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}