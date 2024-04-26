using FluentValidation;

namespace Events.Domain.Validation.Tag
{
    public class TagValidator : AbstractValidator<Entities.Tag>
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
