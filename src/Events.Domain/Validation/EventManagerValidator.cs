using FluentValidation;
using TGF.Common.ROP.Errors;
using Events.Domain.Errors;
using Events.Domain.Contracts.Services;
using TGF.Common.ROP.HttpResult;

namespace Events.Domain.Validation
{
    public class EventManagerValidator : AbstractValidator<Entities.EventManager>
    {
        private readonly IExternalPermissionsService _externalPermissionsService;
        public EventManagerValidator(IExternalPermissionsService aExternalPermissionsService)
        {
            _externalPermissionsService = aExternalPermissionsService;

            RuleFor(manager => manager.MemberId)
                .NotNull();

            RuleFor(manager => manager.MemberId)
                .MustAsync(ValidateMemberPermissions)
                .WithROPError(DomainErrors.Validation.Event.InvalidManager);

            RuleFor(manager => manager.Logbook)
                .MaximumLength(InvariantConstants.EventManager_Logbook_MaxLength);

        }
        private async Task<bool> ValidateMemberPermissions(Guid aMemberId, CancellationToken aCancellationToken = default)
        {
            var lResult = await _externalPermissionsService.GetMemberPermissions(aMemberId, aCancellationToken)
                .Map(permissions => permissions.HasFlag(InvariantConstants.EventManager_ManagerId_RequiredPermissions));
            return lResult.IsSuccess && lResult.Value;
        }
    }
}