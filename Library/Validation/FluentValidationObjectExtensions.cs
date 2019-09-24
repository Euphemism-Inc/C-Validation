// (c) Euphemism Inc. All right reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using Coconut.Library.Validation.Localization;

namespace Coconut.Library.Validation
{
    /// <summary>
    /// Fluent extension methods that can be used to create rules.
    /// </summary>
    public static class FluentValidationObjectExtensions
    {
        /// <summary>
        /// Adds a validation message if the current validatable object is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valObj">The value object.</param>
        /// <returns></returns>
        public static FluentValidationObject<T> IsNull<T>(
            this FluentValidationObject<T> valObj
        )
            where T : class
        {
            if (valObj.ValidatableObject != null)
            {
                valObj.AddValidationMessage(Messages.IsNotNull);
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="valObj">The value object.</param>
        /// <returns></returns>
        public static FluentValidationObject<T> IsNotNull<T>(
            this FluentValidationObject<T> valObj
        )
            where T : class
        {
            if (valObj.ValidatableObject == null)
            {
                valObj.AddValidationMessage(Messages.IsNull);
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is null or empty.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <returns></returns>
        public static FluentValidationObject<string> IsNotNullOrEmpty(
            this FluentValidationObject<string> valObj
        ) {
            if (String.IsNullOrEmpty(valObj.ValidatableObject))
            {
                valObj.AddValidationMessage(Messages.IsNullOrEmpty);
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is empty.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <returns></returns>
        public static FluentValidationObject<string> IsNotEmpty(
            this FluentValidationObject<string> valObj
        ) {
            if (valObj.ValidatableObject != null && String.IsNullOrEmpty(valObj.ValidatableObject))
            {
                valObj.AddValidationMessage(Messages.IsEmpty);
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is not equal to <paramref name="otherObject"/>.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <param name="otherObject">The other object.</param>
        /// <returns></returns>
        public static FluentValidationObject<T> IsEqualTo<T>(
            this FluentValidationObject<T> valObj,
            T otherObject
        )
            where T : IComparable<T>
        {
            if (valObj.ValidatableObject.CompareTo(otherObject) == 0)
            {
                valObj.AddValidationMessage(Messages.IsNotEqualTo);
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is not within range.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static FluentValidationObject<T> IsBetween<T>(
            this FluentValidationObject<T> valObj,
            T min,
            T max
        )
            where T : IComparable<T>
        {
            valObj.IsBiggerThen(min);
            valObj.IsSmallerThen(max);

            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is not longer then <paramref name="min"/>.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static FluentValidationObject<T> IsBiggerThen<T>(
            this FluentValidationObject<T> valObj,
            T min
        )
            where T : IComparable<T>
        {
            if (valObj.ValidatableObject.CompareTo(min) < 0)
            {
                valObj.AddValidationMessage(String.Format(Messages.IsSmallerThen, min));
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is not smaller then <paramref name="max"/>.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static FluentValidationObject<T> IsSmallerThen<T>(
            this FluentValidationObject<T> valObj,
            T max
        )
            where T : IComparable<T>
        {
            if (valObj.ValidatableObject.CompareTo(max) > 0)
            {
                valObj.AddValidationMessage(String.Format(Messages.IsBiggerThen, max));
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is not within range.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static FluentValidationObject<IEnumerable<T>> IsWithinRange<T>(
            this FluentValidationObject<IEnumerable<T>> valObj,
            int min,
            int max
        ) {
            valObj.IsBiggerThen(min - 1);
            valObj.IsSmallerThen(max + 1);

            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is not longer then <paramref name="min"/>.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static FluentValidationObject<IEnumerable<T>> IsBiggerThen<T>(
            this FluentValidationObject<IEnumerable<T>> valObj,
            int min
        ) {
            if (valObj.ValidatableObject != null)
            {
                int count = valObj.ValidatableObject.Count();
                if (count < min)
                {
                    valObj.AddValidationMessage(String.Format(Messages.IsSmallerThen, min));
                }
            }
            return valObj;
        }

        /// <summary>
        /// Adds a validation message if the current validatable object is not smaller then <paramref name="max"/>.
        /// </summary>
        /// <param name="valObj">The value object.</param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static FluentValidationObject<IEnumerable<T>> IsSmallerThen<T>(
            this FluentValidationObject<IEnumerable<T>> valObj,
            int max
        ) {
            if (valObj.ValidatableObject != null)
            {
                int count = valObj.ValidatableObject.Count();
                if (count > max) {
                    valObj.AddValidationMessage(String.Format(Messages.IsBiggerThen, max));
                }
            }
            return valObj;
        }
    }
}
