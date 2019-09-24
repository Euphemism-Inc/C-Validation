// (c) Euphemism Inc. All right reserved.

using Coconut.Library.Validation.Tests.Models;

namespace Coconut.Library.Validation.Tests.Validators
{
    internal class TestModelB_Validator :
        FluentValidator<TestModelB>
    {
        public override void ExecuteValidationRules()
        {
            For(x => x.StringProperty, nameof(Object.StringProperty))
                .IsNotNullOrEmpty();
        }
    }
}
