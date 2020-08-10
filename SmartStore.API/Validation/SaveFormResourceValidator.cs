using FluentValidation;
using SmartStore.API.Resources;

namespace SmartStore.API.Validation
{
    public class SaveFormResourceValidator : AbstractValidator<SaveFormResource>
    {
        public SaveFormResourceValidator()
        {
            RuleFor(m => m.StaffId).NotNull().NotEqual(0);
            RuleFor(m => m.PlantId).NotNull().NotEqual(0);
            RuleFor(m => m.FormType).NotNull();
        }
    }
}
