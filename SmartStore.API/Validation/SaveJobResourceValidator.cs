using FluentValidation;
using SmartStore.API.Resources;

namespace SmartStore.API.Validation
{
    public class SaveJobResourceValidator : AbstractValidator<SaveJobResource>
    {
        public SaveJobResourceValidator()
        {
            RuleFor(m => m.JobNumber)
                .NotEmpty()
                .NotNull();

            RuleFor(m => m.JobPortalId)
                .NotNull()
                .NotEqual(0);

            RuleFor(m => m.PlantId)
                .NotNull()
                .NotEqual(0);

            RuleFor(m => m.JobStatus).NotNull();
        }
    }
}
