using Common.Domain.ValueObjects;
using Events.Domain.Validation;
using TGF.Common.ROP;
using TGF.Common.ROP.HttpResult;

namespace Events.Domain.Contracts.Services
{
    public interface IExternalPermissionsService
    {
        Task<IHttpResult<PermissionsEnum>> GetMemberPermissions(Guid aMemberId, CancellationToken aCancellationToken = default);
    }
}
