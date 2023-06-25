using ServiceStack.FluentValidation;
using Web_API.Resources;

namespace Web_API.Validators
{
    public class SaveRoomResourceValidator : AbstractValidator<SaveRoomResources>
    {
        public SaveRoomResourceValidator()
        {
            RuleFor(r => r.UserID)
                .NotEmpty()
                .WithMessage("'User Id' must not be 0.");
        }
    }
}
