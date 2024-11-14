using FluentValidation;
using TGF.Common.ROP.Errors;
using Events.Domain.Errors;
using Events.Domain.Contracts.Services;
using TGF.Common.ROP.HttpResult.RailwaySwitches;
using Common.Domain.ValueObjects;

namespace Events.Domain.Validation
{
    public class EventManagerValidator : AbstractValidator<Entities.EventManager>
    {
        private readonly IExternalPermissionsService _externalPermissionsService;
        public EventManagerValidator(IExternalPermissionsService aExternalPermissionsService)
        {
            _externalPermissionsService = aExternalPermissionsService;

            RuleFor(manager => manager.GuildId)
                .NotNull();

            RuleFor(manager => manager.UserId)
                .NotNull();

            RuleFor(manager => new MemberKey(manager.GuildId, manager.UserId))
                .MustAsync(ValidateMemberPermissions)
                .WithROPError(DomainErrors.Validation.Event.InvalidManager);

            RuleFor(manager => manager.Logbook)
                .MaximumLength(InvariantConstants.EventManager_Logbook_MaxLength);

        }
        private async Task<bool> ValidateMemberPermissions(MemberKey aMemberKey, CancellationToken aCancellationToken = default)
        {
            var lResult = await _externalPermissionsService.GetMemberPermissions(aMemberKey, aCancellationToken)
                .Map(permissions => permissions.HasFlag(InvariantConstants.EventManager_ManagerId_RequiredPermissions));
            return lResult.IsSuccess && lResult.Value;
        }
    }
}