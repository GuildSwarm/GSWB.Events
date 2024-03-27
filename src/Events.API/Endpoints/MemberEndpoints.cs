using Events.Application.Contracts.Services;
using Events.Application.DTOs;
using Common.Infrastructure.Communication.ApiRoutes;
using Common.Domain.ValueObjects;
using Common.Presentation.Validation;
using Members.API.Validation;
using TGF.CA.Infrastructure.Security.Identity.Authorization.Permissions;
using TGF.CA.Presentation;
using TGF.CA.Presentation.Middleware;
using TGF.CA.Presentation.MinimalAPI;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.API.Endpoints
{
    /// Collection of endpoints to run over the whole guild's member list.
    public class MembersEndpoints : IEndpointDefinition
    {
        /// <inheritdoc/>
        public void DefineEndpoints(WebApplication aWebApplication)
        {
            aWebApplication.MapPost(EventsApiRoutes.events_new, Post_CreateEvent)
                .RequirePermissions(PermissionsEnum.CreateEvents)
                .SetResponseMetadata<string>(200)
                .ProducesValidationProblem();
        }

        /// <inheritdoc/>
        public void DefineRequiredServices(IServiceCollection aRequiredServicesCollection)
        {
        }

        /// <summary>
        /// Creates a new event
        /// </summary>
        private async Task<IResult> Post_CreateEvent(CancellationToken aCancellationToken = default)
        =>
        await Task.FromResult(Result.CancellationTokenResult(aCancellationToken)
        .Map(_ => "Hello")
        .ToIResult());

    }
}
