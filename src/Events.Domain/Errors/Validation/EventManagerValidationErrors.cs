using System.Net;
using TGF.Common.ROP.Errors;

namespace Events.Domain.Errors
{
    public static partial class DomainErrors
    {
        public static partial class Validation
        {
            public static class EventManager
            {
                public static HttpError DeletedLastManager => new(
                new Error("Validation.EventManager.DeletedLastManager",
                    $"It is not allowed to delete all managers of an event, there must be at least 1 manager for all existing events."),
                HttpStatusCode.BadRequest);
            }
        }
    }
}
