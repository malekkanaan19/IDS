using meeting.services.Resources;
using ServiceStack.FluentValidation;
using Web_API.Resources;

namespace Web_API.Validators
{
    public class SaveReservationResourceValidator : AbstractValidator<Resources.SaveReservationResources>
    {
        public SaveReservationResourceValidator()
        {
            RuleFor(r => r.Id)
                .NotNull()
                .MaximumLength(50);

            RuleFor(r => r.UserId)
                .NotNull();
        }
    }
}
