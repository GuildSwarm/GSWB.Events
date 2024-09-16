using Events.Domain.Errors;
using Events.Domain.Validation;
using Events.Domain.Validation.Tag;
using System.Collections.Generic;
using System.Collections.Immutable;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Domain.Entities
{
    public partial class Event
    {
        public DiscordEventChannel? DiscordTemplate { get; private set; }
        public virtual ICollection<EventParticipationRequirement> Requirements { get; private set; } = [];
        public virtual ICollection<EventManager> Managers { get; private set; } = [];
        public virtual ICollection<EventTag> Tags { get; private set; } = [];

        #region Managers
        public async Task<IHttpResult<IEnumerable<EventManager>>> AddManagersAsync(IEnumerable<Guid> aMemberIdList, EventManagerValidator aEventManagerValidator)
        {
            var lResults = new List<EventManager>();

            foreach (var lMemberId in aMemberIdList)
            {
                var lManager = new EventManager(lMemberId, this) { MemberId = lMemberId, Event = this};
                var lValidationResult = await aEventManagerValidator.ValidateAsync(lManager);
                if (!lValidationResult.IsValid)
                    return Result.Failure<IEnumerable<EventManager>>(lValidationResult.Errors
                        .Select(e => ValidateSwitchExtensions.GetValidationError(e.ErrorCode, e.ErrorMessage))
                        .ToImmutableArray()
                    );

                if(!this.Managers.Any(manager => manager.MemberId == lMemberId))
                    this.Managers.Add(lManager);

            }

            return Result.SuccessHttp<IEnumerable<EventManager>>(this.Managers);
        }

        public IHttpResult<IEnumerable<EventManager>> DeleteManagers(IEnumerable<Guid> aMemberIdList)
        => (Managers.Count == 1 && aMemberIdList.Any(memberId => Managers.Any(manager => manager.MemberId == memberId))
            ? Result.Failure<IEnumerable<EventManager>>(DomainErrors.Validation.EventManager.DeletedLastManager) 
            : Result.SuccessHttp(Managers as IEnumerable<EventManager>)
        ).Map(memberIdList => Managers.Where(manager => aMemberIdList.Contains(manager.MemberId)))
        .Tap(managerList => Managers = Managers.Except(managerList).ToList());
        #endregion

        #region Tags
        public async Task<IHttpResult<Event>> AddTagsAsync(IEnumerable<Guid> aTagIdList, TagIdListValidator aTagIdListValidator)
        {
            var lValidationResult = await aTagIdListValidator.ValidateAsync(aTagIdList);

            if (!lValidationResult.IsValid)
                return Result.Failure<Event>(lValidationResult.Errors
                    .Select(e => ValidateSwitchExtensions.GetValidationError(e.ErrorCode, e.ErrorMessage))
                    .ToImmutableArray());

            aTagIdList.Where(tagId => Tags.Any(eventTag => eventTag.TagId == tagId))
            .ToList()
            .ForEach(tagId => Tags.Add(new EventTag() { Event = this, TagId = tagId }));

            return Result.SuccessHttp(this);
        }

        public IHttpResult<IEnumerable<EventTag>> DeleteTags(IEnumerable<Guid> aTagIdList)
        => Result.SuccessHttp(aTagIdList)
            .Map(tagIdList => Tags.Where(eventTag => tagIdList.Contains(eventTag.TagId)))
            .Tap(eventTagList => Tags = Tags.Except(eventTagList).ToList());
        #endregion

        // Add a requirement to the event.
        public async Task<IHttpResult<Event>> AddRequirementsAsync(IEnumerable<Guid> aRequirementIdList)
        {
            aRequirementIdList.Where(participationRequirementId => Requirements.Any(requirement => requirement.ParticipationRequirementId == participationRequirementId))
            .ToList()
            .ForEach(requirementId => Requirements.Add(new EventParticipationRequirement() { Event = this, ParticipationRequirementId = requirementId }));

            return Result.SuccessHttp(this);
        }

    }
}
