using Events.Domain.Contracts.Services;
using Events.Domain.Entities;
using Events.Domain.Errors;
using TGF.Common.ROP;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.Domain.Services
{
    /// <summary>
    /// Domain service with complex business logic, in this case related with the Member entitiy.
    /// </summary>
    //internal class MembersDomainService : IMembersDomainService
    //{
    //    public IHttpResult<Unit> IsNameValid(Member aMember)
    //    => aMember.Name != "InvalidName"
    //        ? Result.SuccessHttp(Unit.Value)
    //        : Result.Failure<Unit>(DomainErrors.Member.InvalidName);
    //}
}
