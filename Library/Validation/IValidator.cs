// (c) Euphemism Inc. All right reserved.

using Coconut.Library.Common;

namespace Coconut.Library.Validation
{
    /// <summary>
    /// A validator for an object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IValidator<T>
    {
        /// <summary>
        /// Executes the validator on the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        Result Execute(T obj);
    }
}
