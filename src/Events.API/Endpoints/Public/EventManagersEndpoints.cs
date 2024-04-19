using Common.Application.DTOs.Events;
using Common.Domain.ValueObjects;
using Common.Infrastructure.Communication.ApiRoutes;
using Events.Application.DTOs;
using Events.Application.UseCases.EventManagers;
using Microsoft.AspNetCore.Mvc;
using TGF.CA.Infrastructure.Security.Identity.Authorization.Permissions;
using TGF.CA.Presentation;
using TGF.CA.Presentation.Middleware;
using TGF.CA.Presentation.MinimalAPI;
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
            aWebApplication.MapPut(EventsApiRoutes.events_addManagers, Post_AddEventManagers)
                .RequirePermissions(PermissionsEnum.ManageEvents)
                .SetResponseMetadata<EventDTO>(200)
                .ProducesValidationProblem();

            aWebApplication.MapDelete(EventsApiRoutes.events_deleteManagers, Delete_DeleteEventManagers)
                .RequirePermissions(PermissionsEnum.ManageEvents)
                .SetResponseMetadata<EventDTO>(200)
                .ProducesValidationProblem();
        }

        /// <inheritdoc/>
        public void DefineRequiredServices(IServiceCollection aRequiredServicesCollection)
        {
        }

        /// <summary>
        /// Creates a new event
        /// </summary>
        private async Task<IResult> Post_AddEventManagers(EventManagersDTO aAddEventManagersDTO, [FromServices] AddEventManagersService aAddEventManagersService, CancellationToken aCancellationToken = default)
        => await aAddEventManagersService.AddManagers(aAddEventManagersDTO, aCancellationToken)
        .ToIResult();

        private async Task<IResult> Delete_DeleteEventManagers(EventManagersDTO aAddEventManagersDTO, [FromServices] DeleteEventManagersService aDeleteEventManagersService, CancellationToken aCancellationToken = default)
        => await aDeleteEventManagersService.DeleteManagers(aAddEventManagersDTO, aCancellationToken)
        .ToIResult();

    }
}
