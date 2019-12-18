using System;

namespace Oeuvre.Domain.ValueObjects {
    public interface IValueObject<T> : IEquatable<T> { }
}