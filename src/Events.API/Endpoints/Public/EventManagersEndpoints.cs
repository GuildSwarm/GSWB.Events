using Common.Application.Communication.Routing;
using Common.Application.DTOs.Events;
using Common.Domain.ValueObjects;
using Events.Application.Contracts.UseCases.EventManagers;
using Microsoft.AspNetCore.Mvc;
using TGF.CA.Infrastructure.Security.Identity.Authorization.Permissions;
using TGF.CA.Presentation;
using TGF.CA.Presentation.Middleware;
using TGF.CA.Presentation.MinimalAPI;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;

namespace Events.API.Endpoints.Public
{
    /// <summary>
    /// 
    /// </summary>
    public class EventManagersEndpoints : IEndpointDefinition
    {
        /// <inheritdoc/>
        public void DefineEndpoints(WebApplication aWebApplication)
        {
            aWebApplication.MapGet(EventsApiRoutes.events_managers, Get_AddEventManagers)
                .RequirePermissions(PermissionsEnum.ManageEvents)
                .SetResponseMetadata<EventManagerDetailDTO>(200)
                .ProducesValidationProblem();

            aWebApplication.MapPut(EventsApiRoutes.events_managers, Post_AddEventManagers)
                .RequirePermissions(PermissionsEnum.ManageEvents)
                .SetResponseMetadata<IEnumerable<EventManagerDetailDTO>>(200)
                .ProducesValidationProblem();

            aWebApplication.MapDelete(EventsApiRoutes.events_managers, Delete_DeleteEventManagers)
                .RequirePermissions(PermissionsEnum.ManageEvents)
                .SetResponseMetadata<IEnumerable<EventManagerDetailDTO>>(200)
                .ProducesValidationProblem();
        }

        /// <inheritdoc/>
        public void DefineRequiredServices(IServiceCollection aRequiredServicesCollection)
        {
        }

        /// <summary>
        /// List all managers of an event.
        /// </summary>
        private async Task<IResult> Get_AddEventManagers(Guid id, HttpContext aHttpContext, [FromServices] IListEventManagersService aListEventManagersService, CancellationToken aCancellationToken = default)
        => await Result.ContextAccessTokenResult(aHttpContext)
        .Bind(accessToken => aListEventManagersService.ListManagers(id, accessToken, aCancellationToken))
        .ToIResult();

        /// <summary>
        /// Adds a list of new managers to the event from a list of memberId
        /// </summary>
        private async Task<IResult> Post_AddEventManagers(Guid id, HttpContext aHttpContext, [FromBody] IEnumerable<Guid> aMemberIdList, [FromServices] IAddEventManagersService aAddEventManagersService, CancellationToken aCancellationToken = default)
        => await  Result.ContextAccessTokenResult(aHttpContext)
        .Bind(accessToken => aAddEventManagersService.AddManagers(new EventManagersDTO(id, aMemberIdList), accessToken, aCancellationToken))
        .ToIResult();

        /// <summary>
        /// Deletes a list if manages for the event from their memberId
        /// </summary>
        private async Task<IResult> Delete_DeleteEventManagers(Guid id, HttpContext aHttpContext, [FromBody] IEnumerable<Guid> aMemberIdList, [FromServices] IDeleteEventManagersService aDeleteEventManagersService, CancellationToken aCancellationToken = default)
        => await Result.ContextAccessTokenResult(aHttpContext)
        .Bind(accessToken => aDeleteEventManagersService.DeleteManagers(id, accessToken, aMemberIdList, aCancellationToken))
        .ToIResult();

    }
}
