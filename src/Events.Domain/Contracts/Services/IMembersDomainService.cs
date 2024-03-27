using Events.Domain.Entities;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP;

namespace Events.Domain.Contracts.Services
{
    /// <summary>
    /// Interface for a domain service with complex business logic, in this case related with the Member entitiy.
    /// </summary>
    internal interface IMembersDomainService
    {
        public IHttpResult<Unit> IsNameValid(Member aMember);
    }
}
