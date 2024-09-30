using Common.Application.DTOs.Events;
using Events.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.Common.ROP.HttpResult;

namespace Events.Application.Contracts.UseCases.Events
{
    public interface ICreateEventService
    {
        Task<IHttpResult<EventDTO>> CreateEvent(Guid aMembeIdCreator, CreateEventDTO aCreateEventDTO, CancellationToken aCancellationToken = default);

    }
}
