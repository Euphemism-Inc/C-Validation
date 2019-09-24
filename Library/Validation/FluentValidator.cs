// (c) Euphemism Inc. All right reserved.

using Coconut.Library.Common;
using System;

namespace Coconut.Library.Validation
{
    /// <summary>
    /// The fluent implementation of a validator. Not thread safe.
    /// </summary>
    /// <typeparam name="T">Type of the object being validated.</typeparam>
    /// <seealso cref="BaseValidator{T}" />
    public abstract class FluentValidator<T> : BaseValidator<T>
        where T : class
    {
        /// <summary>
        /// Executes a different validator on a property (of an array type) of the current object.
        /// </summary>
        /// <typeparam name="TValidator">The type of the new validator.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="selector">The selector func.</param>
        /// <param name="validatorCtorParams">Arguments for the constructor of <typeparamref name="TValidator"/></param>
        public void ExecuteValidatorOnList<TValidator, TProperty>(Func<T, TProperty[]> selector, params object[] validatorCtorParams)
            where TProperty : class
            where TValidator : FluentValidator<TProperty>
        {
            TProperty[] models = selector(Object);
            for (int i = 0; i < models.Length; i++)
            {
                ExecuteValidator<TValidator, TProperty>(x => models[i], validatorCtorParams);
            }
        }

        /// <summary>
        /// Executes a different validator on a property (of an array type) of the current object.
        /// </summary>
        /// <typeparam name="TValidator">The type of the new validator.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="selector">The selector func.</param>
        /// <param name="validatorCtorParams">Arguments for the constructor of <typeparamref name="TValidator"/></param>
        [Obsolete("It is better to create a validator object using dependency injection and insert it in the constructor of the validator using this function.")]
        public void ExecuteValidatorOnListIfNotNull<TValidator, TProperty>(Func<T, TProperty[]> selector, params object[] validatorCtorParams)
            where TProperty : class
            where TValidator : FluentValidator<TProperty>
        {
            TProperty[] models = selector(Object);
            if (models != null)
            {
                ExecuteValidatorOnList<TValidator, TProperty>(selector, validatorCtorParams);
            }
        }

        /// <summary>
        /// Executes a different validator on a property of the current object.
        /// </summary>
        /// <typeparam name="TValidator">The type of the new validator.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="selector">The selector func.</param>
        /// <param name="validatorCtorParams">Arguments for the constructor of <typeparamref name="TValidator"/></param>
        [Obsolete("It is better to create a validator object using dependency injection and insert it in the constructor of the validator using this function.")]
        public void ExecuteValidator<TValidator, TProperty>(Func<T, TProperty> selector, params object[] validatorCtorParams)
            where TValidator : FluentValidator<TProperty>
            where TProperty : class
        {
            TProperty property = selector(Object);
            ExecuteValidator<TValidator, TProperty>(property, validatorCtorParams);
        }

        /// <summary>
        /// Executes a different validator on a property of the current object if that property is not null.
        /// </summary>
        /// <typeparam name="TValidator">The type of the new validator.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="selector">The selector func.</param>
        /// <param name="validatorCtorParams">Arguments for the constructor of <typeparamref name="TValidator"/></param>
        [Obsolete("It is better to create a validator object using dependency injection and insert it in the constructor of the validator using this function.")]
        public void ExecuteValidatorIfNotNull<TValidator, TProperty>(Func<T, TProperty> selector, params object[] validatorCtorParams)
            where TValidator : FluentValidator<TProperty>
            where TProperty : class
        {
            TProperty property = selector(Object);
            if (property != null)
            {
                ExecuteValidator<TValidator, TProperty>(property, validatorCtorParams);
            }
        }

        /// <summary>
        /// Executes a different validator on a property of the current object.
        /// </summary>
        /// <typeparam name="TValidator">The type of the new validator.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="property">The value of the property.</param>
        /// <param name="validatorCtorParams">Arguments for the constructor of <typeparamref name="TValidator"/></param>
        [Obsolete("It is better to create a validator object using dependency injection and insert it in the constructor of the validator using this function.")]
        private void ExecuteValidator<TValidator, TProperty>(TProperty property, params object[] validatorCtorParams)
            where TValidator : FluentValidator<TProperty>
            where TProperty : class
        {
            var validator = (TValidator)Activator.CreateInstance(typeof(TValidator), validatorCtorParams);
            var result = validator.Execute(property);

            foreach (ValidationMessage validationMessage in result.ValidationMessages)
            {
                ValidationMessages.Add(validationMessage);
            }
        }

        /// <summary>
        /// Start the fluent validation syntax for a property.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <param name="objectSelector">The object selector.</param>
        /// <param name="objectName">Name of the object.</param>
        /// <returns></returns>
        public FluentValidationObject<TOut> For<TOut>(
            Func<T, TOut> objectSelector,
            string objectName
        ) {
            if (objectSelector == null) throw new ArgumentNullException("Parameter is empty.", nameof(objectSelector));

            if (objectName == null) throw new ArgumentNullException("Parameter is empty.", nameof(objectName));
            if (string.IsNullOrEmpty(objectName)) throw new ArgumentException("Parameter is empty.", nameof(objectName));

            TOut selectedObject = objectSelector(Object);
            return new FluentValidationObject<TOut>(
                selectedObject,
                objectName,
                ValidationMessages.Add
            );
        }
    }
}
