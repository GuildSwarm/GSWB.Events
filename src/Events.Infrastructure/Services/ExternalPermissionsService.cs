using Common.Infrastructure.Communication.HTTP;
using Events.Domain.Contracts.Services;
using TGF.CA.Infrastructure.Discovery;

namespace Events.Infrastructure.Services
{
    public class ExternalPermissionsService(IServiceDiscovery aServiceDiscovery, IHttpClientFactory aHttpClientFactory) 
        : MembersCommunicationService(aServiceDiscovery, aHttpClientFactory), IExternalPermissionsService
    {
    }
}
