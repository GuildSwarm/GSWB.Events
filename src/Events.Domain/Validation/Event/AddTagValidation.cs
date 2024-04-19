using Events.Domain.Errors;
using FluentValidation;
using TGF.Common.ROP.Errors;

namespace Events.Domain.Validation.Event
{
    public class AddTagValidator : AbstractValidator<Entities.Event>
    {
        public AddTagValidator()
        {
            RuleFor(eventEntitiy => eventEntitiy.Tags)
            .Must(tags => tags.Count <= 5)
            .WithROPError(DomainErrors.Validation.Event.TagLimitExceeded);
        }
    }
}
