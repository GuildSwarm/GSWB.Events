using FluentValidation;

namespace Events.Domain.Validation
{
    public class TagValidator : AbstractValidator<Entities.EventTag>
    {
        public TagValidator() 
        {
            RuleFor(tag => tag)
                .NotNull();

            RuleFor(tag => tag.Name)
                .NotEmpty()
                .MaximumLength(InvariantConstants.EventTag_Name_MaxLength);

            RuleFor(tag => tag.Description)
                .MaximumLength(InvariantConstants.EventTag_Description_MaxLength);

        }
    }
}
