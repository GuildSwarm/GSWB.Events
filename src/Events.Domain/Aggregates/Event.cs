using Events.Domain.Contracts.Services;
using Events.Domain.Validation;
using Events.Domain.Validation.Event;
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

        #region Tags
        public IHttpResult<EventTag> AddTag(EventTag aTag)
        => Result.SuccessHttp(aTag)
            .Validate(aTag, new TagValidator())
            .Tap(Tags.Add)
            .Validate(this, new AddTagValidator());

        public IHttpResult<EventTag> RemoveTag(EventTag aTag)
        => Result.SuccessHttp(aTag)
            .Tap(tag => Tags.Remove(tag));
        #endregion

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


        // Add a requirement to the event.
        public void AddRequirement(EventRequirement requirement)
        {
            if (requirement == null) throw new ArgumentNullException(nameof(requirement));
            Requirements.Add(requirement);
            // Additional logic can be implemented here.
        }

    }
}
