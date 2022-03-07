// <copyright file="ValueObject.cs" company="SuitSupply">
// Copyright © 2015-2020 SuitSupply. All Rights Reserved.
// </copyright>

namespace SuitSupply.Platform.Infrastructure.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class ValueObject
    {
        /// <summary>
        /// Helper function for implementing overloaded equality operator.
        /// </summary>
        /// <param name="left">Left-hand side object.</param>
        /// <param name="right">Right-hand side object.</param>
        /// <returns>bool.</returns>
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        /// <summary>
        /// Helper function for implementing overloaded inequality operator.
        /// </summary>
        /// <param name="left">Left-hand side object.</param>
        /// <param name="right">Right-hand side object.</param>
        /// <returns>bool.</returns>
        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        /// <summary>
        /// To be overridden in inheriting classes for providing a collection of atomic values of
        /// this Value Object.
        /// </summary>
        /// <returns>Collection of atomic values.</returns>
        protected abstract IEnumerable<object> GetAtomicValues();

        /// <summary>
        /// Compares two Value Objects according to atomic values returned by <see cref="GetAtomicValues"/>.
        /// </summary>
        /// <param name="obj">Object to compare to.</param>
        /// <returns>True if objects are considered equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValues = this.GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }

                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }

            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }

        /// <summary>
        /// Returns hashcode value calculated according to a collection of atomic values
        /// returned by <see cref="GetAtomicValues"/>.
        /// </summary>
        /// <returns>Hashcode value.</returns>
        public override int GetHashCode()
        {
            return this.GetAtomicValues()
               .Select(x => x != null ? x.GetHashCode() : 0)
               .Aggregate((x, y) => x ^ y);
        }
    }
}
