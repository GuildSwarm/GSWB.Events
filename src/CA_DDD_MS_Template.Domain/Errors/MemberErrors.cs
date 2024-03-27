using System.Net;
using TGF.Common.ROP.Errors;

namespace Events.Domain.Errors
{
    public static partial class DomainErrors
    {
        public static class Member
        {
            public static HttpError InvalidName => new(
            new Error("Member.InvalidName",
                "The Member name is invalid."),
            HttpStatusCode.BadRequest);
            public static HttpError InvalidNickname => new(
            new Error("Member.InvalidNickname",
                "The Member nickname is invalid."),
            HttpStatusCode.BadRequest);

        }
    }
}
