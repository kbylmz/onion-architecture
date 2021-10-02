using System;
using System.Collections;
using System.Collections.Generic;

namespace Hestia.Domain.Models
{
    public struct Optional<T> : IEnumerable<T>, IEquatable<Optional<T>>
    {
        /// <summary>
        ///     The empty instance.
        /// </summary>
        public static readonly Optional<T> Empty = new Optional<T>();

        readonly bool hasValue;
        readonly T value;


        public Optional(T value)
        {
            hasValue = true;
            this.value = value;
        }

        public bool HasValue
        {
            get { return hasValue; }
        }

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new InvalidOperationException("Optional object must have a value.");
                }

                return value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (HasValue)
            {
                yield return value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(Optional<T> other)
        {
            return hasValue.Equals(other.hasValue) &&
                   EqualityComparer<T>.Default.Equals(value, other.value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((Optional<T>)obj);
        }

        public static bool operator ==(Optional<T> instance1, Optional<T> instance2)
        {
            return instance1.Equals(instance2);
        }

        public static bool operator !=(Optional<T> instance1, Optional<T> instance2)
        {
            return !instance1.Equals(instance2);
        }

        public override int GetHashCode()
        {
            return hasValue.GetHashCode() ^ EqualityComparer<T>.Default.GetHashCode(value) ^ typeof(T).GetHashCode();
        }
    }
}
