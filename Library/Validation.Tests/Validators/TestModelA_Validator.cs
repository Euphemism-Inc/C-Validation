// (c) Euphemism Inc. All right reserved.

using Coconut.Library.Validation.Tests.Models;

namespace Coconut.Library.Validation.Tests.Validators
{
    internal class TestModelA_Validator :
        FluentValidator<TestModelA>
    {
        public override void ExecuteValidationRules()
        {
            For(x => x.StringProperty, nameof(Object.StringProperty))
                .IsNotNullOrEmpty();

            For(x => x.ObjectProperty, nameof(Object.ObjectProperty))
                .IsNotNull();

            ExecuteValidatorIfNotNull<TestModelB_Validator, TestModelB>(x => x.ObjectProperty);
        }
    }
}
