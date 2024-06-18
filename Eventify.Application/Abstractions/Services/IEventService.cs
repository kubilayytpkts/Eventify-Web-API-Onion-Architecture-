using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task CreateEventAsync(CreateEventDTO events);
        Task<IEnumerable<EventDTO>> GetAllEventAsync(Pagination pagination);
    }
}
