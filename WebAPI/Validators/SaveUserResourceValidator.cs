using meeting.services.Resources;
using ServiceStack.FluentValidation;
using Web_API.Resources;

namespace Web_API.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<Resources.SaveUserResources>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(r => r.Id)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }

        internal Task ValidateAsync(meeting.services.Resources.SaveUserResources saveUserResource)
        {
            throw new NotImplementedException();
        }
    }
}
