// (c) Euphemism Inc. All right reserved.

using Coconut.Library.Validation.Tests.Models;
using Coconut.Library.Validation.Tests.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Coconut.Library.Validation.Tests
{
    /// <summary>
    /// Tests for <see cref="FluentValidator{T}"/>.
    /// </summary>
    [TestClass]
    public class FluentValidatorTests
    {
        /// <summary>
        /// Execute a <see cref="FluentValidator{T}"/> with a valid outcome.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("Library")]
        [TestCategory("Validation")]
        public void FluentValidator_Execute_Validator_Valid_Succeeds()
        {
            IValidator<TestModelA> validator = new TestModelA_Validator();
            var ObjectToValidate = new TestModelA()
            {
                StringProperty = "NotEmptyOrNull",
                ObjectProperty = new TestModelB()
                {
                    StringProperty = "NotEmptyOrNull"
                }
            };

            var result = validator.Execute(ObjectToValidate);

            Assert.IsTrue(result.Success);
            Assert.AreEqual(0, result.ValidationMessages.Count);
        }

        /// <summary>
        /// Execute a <see cref="FluentValidator{T}"/> with an invalid outcome.
        /// </summary>
        [TestMethod]
        [TestCategory("UnitTest")]
        [TestCategory("Library")]
        [TestCategory("Validation")]
        public void FluentValidator_Execute_Validator_InValid_Succeeds()
        {
            IValidator<TestModelA> validator = new TestModelA_Validator();
            var ObjectToValidate = new TestModelA()
            {
                StringProperty = null,
                ObjectProperty = new TestModelB()
                {
                    StringProperty = null
                }
            };

            var result = validator.Execute(ObjectToValidate);

            Assert.IsFalse(result.Success);
            Assert.AreEqual(2, result.ValidationMessages.Count);
        }
    }
}