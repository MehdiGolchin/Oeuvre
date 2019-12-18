using System.Collections.Generic;

namespace Oeuvre.Collections {
    /// <summary>
    /// 
    /// </summary>
    public static class SinglyLinkedExtensions {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="head"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static SinglyLinked<T> Push<T>(this SinglyLinked<T> source, T head) =>
            new SinglyLinked<T>(head, source);
    }
}