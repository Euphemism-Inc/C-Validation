// (c) Euphemism Inc. All right reserved.

namespace Coconut.Library.Common
{
    /// <summary>
    /// A <see cref="Result"/> with an object.
    /// </summary>
    /// <typeparam name="T">Type of the returned object.</typeparam>
    /// <seealso cref="Result" />
    public sealed class Result<T> : Result
    {
        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        public T Object { get; set; }
    }
}
