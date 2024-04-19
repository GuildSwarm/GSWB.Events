using Events.Domain.Validation;
using TGF.Common.ROP.Errors;

namespace Events.Domain.Errors
{
    public static partial class DomainErrors
    {
        public static partial class Validation
        {
            public static class Event
            {
                public static Error TagLimitExceeded => new(
                     "Validation.Event.TagLimitExceeded",
                     $"The limit number of assinged tags for the event was exceeded, the current tag number limit is {InvariantConstants.Event_Tags_Limit}"
                 );
                public static Error InvalidManager => new(
                     "Validation.Event.InvalidManager",
                     $"The event has an invalid manager, members without permissions to manage events cannot be assinged as an event manager"
                );
            }
        }
    }
}
