using System;
using System.Collections;
using System.Collections.Generic;

namespace Oeuvre.Collections {
    internal class SinglyLinkedEnumerator<T> : IEnumerator<T>, IDisposable {
        private readonly SinglyLinked<T> _start;
        private SinglyLinked<T> _current;

        public SinglyLinkedEnumerator(SinglyLinked<T> items) {
            _start = items;
        }

        public T Current => _current is null ? default : _current.Head;

        object IEnumerator.Current => Current;

        public bool MoveNext() {
            _current = _current is null ? _start : _current.Tail;
            return !(_current is null);
        }

        public void Reset() {
            _current = _start;
        }

        public void Dispose() { }
    }
}