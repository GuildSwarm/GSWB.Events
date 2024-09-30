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
using Events.Application.Contracts.UseCases.Events;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Common.Infrastructure.Security;

namespace Events.API.Endpoints.Public
{
    /// Collection of endpoints to run over the whole guild's member list.
    public class EventEndpoints : IEndpointDefinition
    {
        /// <inheritdoc/>
        public void DefineEndpoints(WebApplication aWebApplication)
        {
            aWebApplication.MapPost(EventsApiRoutes.events, Post_CreateEvent)
                .RequirePermissions(PermissionsEnum.ManageEvents)
                .SetResponseMetadata<EventDTO>(200)
                .ProducesValidationProblem();

            aWebApplication.MapGet(EventsApiRoutes.events, Get_EventList)
                .RequirePermissions(PermissionsEnum.AccessEvents)
                .SetResponseMetadata<PaginatedListDTO<EventDTO>>(200)
                .ProducesValidationProblem();
        }

        /// <inheritdoc/>
        public void DefineRequiredServices(IServiceCollection aRequiredServicesCollection)
        {
        }

        /// <summary>
        /// Creates a new event, the member who created the event will be the default manager
        /// </summary>
        private async Task<IResult> Post_CreateEvent(
            [FromBody] CreateEventDTO aCreateEventDto,
            [FromServices] ICreateEventService aCreateEventService,
            [FromServices] TokenClaimsValidator aTokenClaimsValidator,
            ClaimsPrincipal aClaimsPrincipal,
            CancellationToken aCancellationToken = default)
        {
            return await Result.CancellationTokenResult(aCancellationToken)
                .Validate(aClaimsPrincipal, aTokenClaimsValidator)
                .Bind(discodMemberId => aCreateEventService.CreateEvent(Guid.Parse(aClaimsPrincipal.FindFirstValue(GuildSwarmClaims.MemberId)!), aCreateEventDto, aCancellationToken))
                .ToIResult();
        }

        /// <summary>
        /// Get the list of events(<see cref="PaginatedListDTO{T}"/>) under filtering and pagination conditions specified in the request's query parameters and sorted by a given column name.
        /// </summary>
        private async Task<IResult> Get_EventList(IListEventsService aListEventsService, PaginationValidator aPaginationValidator,
            int page = 1, int pageSize = 20, string sortBy = nameof(EventDTO.Name),
            CancellationToken aCancellationToken = default)
        =>
        await Result.CancellationTokenResult(aCancellationToken)
        .Bind(_ => aListEventsService.ListEvents(page, pageSize, sortBy, aCancellationToken))
        .ToIResult();

    }
}
