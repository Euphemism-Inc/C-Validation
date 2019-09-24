// (c) Euphemism Inc. All right reserved.

using System;
using System.Linq;
using System.Collections.Generic;
using Coconut.Library.Common;

namespace Coconut.Library.Validation
{
    /// <summary>
    /// The basic implementation for a validator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="IValidator{T}" />
    public abstract class BaseValidator<T> : IValidator<T>
    {
        /// <summary>
        /// The current object to validate.
        /// </summary>
        protected T Object { get; private set; }

        /// <summary>
        /// Gets the validation messages during the current validation.
        /// </summary>
        protected IList<ValidationMessage> ValidationMessages { get; private set; }

        /// <summary>
        /// Executes the validation on the specified object.
        /// </summary>
        /// <param name="validatableObject">The validatable object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">validatableObject</exception>
        public Result Execute(T validatableObject)
        {
            if (validatableObject == null) throw new ArgumentNullException(nameof(validatableObject));

            Object = validatableObject;
            ValidationMessages = new List<ValidationMessage>();

            ExecuteValidationRules();

            return new Result() {
                Success = ValidationMessages.Count == 0,
                ValidationMessages = ValidationMessages.ToList()
            };
        }

        /// <summary>
        /// Executes the validation rules.
        /// </summary>
        public abstract void ExecuteValidationRules();
    }
}