using ServiceStack.FluentValidation;
using Web_API.Resources;

namespace Web_API.Validators
{
    public class SaveCompanyResourceValidator : AbstractValidator<SaveCompanyResources>
    {
        public SaveCompanyResourceValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .NotNull();


        }
    }
}
