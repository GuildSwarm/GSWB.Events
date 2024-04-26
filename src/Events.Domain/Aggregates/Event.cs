using Events.Domain.Contracts.Services;
using Events.Domain.Validation;
using Events.Domain.Validation.Event;
using Events.Domain.Validation.Tag;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TGF.Common.ROP;
using TGF.Common.ROP.Errors;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Domain.Entities
{
    public partial class Event
    {
        public DiscordEventChannel? DiscordTemplate { get; private set; }
        public virtual ICollection<EventRequirement> Requirements { get; private set; } = [];
        public virtual ICollection<EventManager> Managers { get; private set; } = [];
        public virtual ICollection<EventTag> Tags { get; private set; } = [];

        #region Managers
        public IHttpResult<IEnumerable<EventManager>> AddManagers(IEnumerable<Guid> aMemberIdList, EventManagerValidator aEventManagerValidator)
        {
            var lResults = new List<EventManager>();

            foreach (var lMemberId in aMemberIdList)
            {
                var lManager = new EventManager(lMemberId, this) { MemberId = lMemberId, Event = this};
                var lValidationResult = aEventManagerValidator.Validate(lManager);
                if (lValidationResult.IsValid)
                    return Result.Failure<IEnumerable<EventManager>>(lValidationResult.Errors
                        .Select(e => ValidateSwitchExtensions.GetValidationError(e.ErrorCode, e.ErrorMessage))
                        .ToImmutableArray()
                    );

                this.Managers.Add(lManager);
                lResults.Add(lManager);
            }

            return Result.SuccessHttp<IEnumerable<EventManager>>(lResults);
        }

        public IHttpResult<IEnumerable<EventManager>> DeleteManagers(IEnumerable<Guid> aMemberIdList)
        => Result.SuccessHttp(aMemberIdList)
            .Map(memberIdList => Managers.Where(manager => memberIdList.Contains(manager.Id)))
            .Tap(managerList => Managers = Managers.Except(managerList).ToList());
        #endregion

        #region Tags
        public IHttpResult<Event> AddTags(IEnumerable<Guid> aTagIdList, TagIdListValidator aTagIdListValidator)
        {
            var lValidationResult = aTagIdListValidator.Validate(aTagIdList);

            if (!lValidationResult.IsValid)
                return Result.Failure<Event>(lValidationResult.Errors
                    .Select(e => ValidateSwitchExtensions.GetValidationError(e.ErrorCode, e.ErrorMessage))
                    .ToImmutableArray());

            aTagIdList.Where(tagId => Tags.Any(eventTag => eventTag.TagId == tagId))
            .ToList()
            .ForEach(tagId => Tags.Add(new EventTag() { EventId = this.Id, TagId = tagId }));

            return Result.SuccessHttp(this);
        }

        public IHttpResult<IEnumerable<EventTag>> DeleteTags(IEnumerable<Guid> aTagIdList)
        => Result.SuccessHttp(aTagIdList)
            .Map(tagIdList => Tags.Where(eventTag => tagIdList.Contains(eventTag.TagId)))
            .Tap(eventTagList => Tags = Tags.Except(eventTagList).ToList());
        #endregion

        // Add a requirement to the event.
        public void AddRequirement(EventRequirement requirement)
        {
            if (requirement == null) throw new ArgumentNullException(nameof(requirement));
            Requirements.Add(requirement);
            // Additional logic can be implemented here.
        }

    }
}
