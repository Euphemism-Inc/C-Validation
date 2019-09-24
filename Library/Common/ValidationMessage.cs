// (c) Euphemism Inc. All right reserved.

using System;

namespace Coconut.Library.Common
{
    /// <summary>
    /// A validation message for a property of an object.
    /// </summary>
    public sealed class ValidationMessage
    {
        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationMessage"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="message">The message.</param>
        public ValidationMessage(string propertyName, string message)
        {
            if (propertyName == null) throw new ArgumentNullException("Parameter is empty.", nameof(propertyName));
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException("Parameter is empty.", nameof(propertyName));

            if (message == null) throw new ArgumentNullException("Parameter is empty.", nameof(message));
            if (string.IsNullOrEmpty(message)) throw new ArgumentException("Parameter is empty.", nameof(message));

            PropertyName = propertyName;
            Message = message;
        }
    }
}
