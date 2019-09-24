// (c) Euphemism Inc. All right reserved.

using System.Collections.Generic;

namespace Coconut.Library.Common
{
    /// <summary>
    /// A result with <see cref="ValidationMessage"/>s.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Result"/> is successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the validation messages.
        /// </summary>
        public IReadOnlyList<ValidationMessage> ValidationMessages { get; set; }
    }
}
