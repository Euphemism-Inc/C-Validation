// (c) Euphemism Inc. All right reserved.

using Coconut.Library.Common;
using System;

namespace Coconut.Library.Validation
{
    /// <summary>
    /// A helper to the fluent implementation of a validator. Not thread safe.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class FluentValidationObject<T>
    {
        /// <summary>
        /// Gets the current object that is being validated.
        /// </summary>
        public T ValidatableObject { get; }

        /// <summary>
        /// Gets the name of the property that is being validated.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// The add a validation message action.
        /// </summary>
        private Action<ValidationMessage> AddValidationMessageAction { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FluentValidationObject{T}"/> class.
        /// </summary>
        /// <param name="validatableObject">The validatable object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="addValidationMessageAction">The add validation message action.</param>
        internal FluentValidationObject(
            T validatableObject,
            string propertyName,
            Action<ValidationMessage> addValidationMessageAction
        ) {
            if (propertyName == null) throw new ArgumentNullException("Parameter is empty.", nameof(propertyName));
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Parameter is empty.", nameof(propertyName));

            if (addValidationMessageAction == null) throw new ArgumentNullException("Parameter is empty.", nameof(addValidationMessageAction));

            ValidatableObject = validatableObject;
            PropertyName = propertyName;
            AddValidationMessageAction = addValidationMessageAction;
        }

        /// <summary>
        /// Adds a validation message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void AddValidationMessage(string message)
        {
            var validationMessage = new ValidationMessage(PropertyName, message);
            AddValidationMessageAction(validationMessage);
        }

        internal object Count() => throw new NotImplementedException();
    }
}
