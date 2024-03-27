using Events.Domain.Entities;
using Events.Domain.Errors;
using FluentValidation;

namespace Events.Domain.Validation
{
    public class MemberNameLengthValidator : AbstractValidator<Member>
    {
        public MemberNameLengthValidator()
        {
            RuleFor(member => member.Name)
                .Length(0, 32).WithMessage(DomainErrors.Validation.Member.TooLongNameLength);
        }
    }
}
