using Events.Application.Contracts.Services;
using Events.Application.DTOs;
using Common.Infrastructure.Communication.ApiRoutes;
using Common.Domain.ValueObjects;
using Common.Presentation.Validation;
using TGF.CA.Infrastructure.Security.Identity.Authorization.Permissions;
using TGF.CA.Presentation;
using TGF.CA.Presentation.Middleware;
using TGF.CA.Presentation.MinimalAPI;
using TGF.Common.ROP.HttpResult;
using TGF.Common.ROP.Result;
using TGF.CA.Application.DTOs;
using Common.Application.DTOs.Events;

namespace Events.API.Endpoints.Public
{
    /// Collection of endpoints to run over the whole guild's member list.
    public class EventEndpoints : IEndpointDefinition
    {
        /// <inheritdoc/>
        public void DefineEndpoints(WebApplication aWebApplication)
        {
            aWebApplication.MapPost(EventsApiRoutes.events_new, Post_CreateEvent)
                .RequirePermissions(PermissionsEnum.ManageEvents)
                .SetResponseMetadata<string>(200)
                .ProducesValidationProblem();

            aWebApplication.MapGet(EventsApiRoutes.events_list, Get_EventList)
                .RequirePermissions(PermissionsEnum.AccessEvents)
                .SetResponseMetadata<PaginatedListDTO<EventDTO>>(200)
                .ProducesValidationProblem();
        }

        /// <inheritdoc/>
        public void DefineRequiredServices(IServiceCollection aRequiredServicesCollection)
        {
        }

        /// <summary>
        /// Creates a new event
        /// </summary>
        private async Task<IResult> Post_CreateEvent(CreateEventDTO aCreateEventDto, CancellationToken aCancellationToken = default)
        =>
        await Task.FromResult(Result.CancellationTokenResult(aCancellationToken)
        .Map(_ => "Hello")
        .ToIResult());

        /// <summary>
        /// Get the list of events(<see cref="PaginatedListDTO{T}"/>) under filtering and pagination conditions specified in the request's query parameters and sorted by a given column name.
        /// </summary>
        private async Task<IResult> Get_EventList(IEventsService aEventsService, PaginationValidator aPaginationValidator,
            int page = 1, int pageSize = 20, string sortBy = nameof(EventDTO.Name),
            CancellationToken aCancellationToken = default)
        =>
        await Result.CancellationTokenResult(aCancellationToken)
        .Bind(_ => aEventsService.GetEventList(page, pageSize, sortBy, aCancellationToken))
        .ToIResult();

    }
}
