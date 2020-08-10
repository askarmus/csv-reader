using FluentValidation;
using SmartStore.API.Resources;

namespace SmartStore.API.Validation
{
    public class SaveDynamicFormResourceValidator : AbstractValidator<SaveDynamicFormResource>
    {
        public SaveDynamicFormResourceValidator()
        {
            RuleFor(r => r.JobId)
                .NotNull()
                .NotEqual(0);

            RuleFor(r => r.DynamicFieldId)
                .NotNull()
                .NotEqual(0);
        }
    }
}
