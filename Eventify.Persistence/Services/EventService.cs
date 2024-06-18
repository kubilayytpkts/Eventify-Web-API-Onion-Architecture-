using Eventify.Application.Abstractions.Services;
using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Eventify.Domain.Entities;
using Eventify.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Persistence.Services
{
    public class EventService : IEventService
    {
        private readonly EventifyDbContext _dbContexts;

        public EventService(EventifyDbContext dbContexts)
        {
            _dbContexts = dbContexts;
        }

        public async Task CreateEventAsync(CreateEventDTO events)
        {
            if (events is not null)
            {
                await _dbContexts.events.AddAsync(new Event
                {
                    Title = events.Title,
                    Date = events.Date,
                    Location = events.Location
                });

                await _dbContexts.SaveChangesAsync();
            }
            else
                 throw new NullReferenceException();
          
        }

        public async Task<IEnumerable<EventDTO>> GetAllEventAsync(Pagination pagination)
        {
            return await _dbContexts.events
                .AsNoTracking()
                .Select(x => new EventDTO()
            {
                Title = x.Title,
                Date = x.Date,
                Location = x.Location
            })
               .Skip(pagination.PageCount * pagination.ItemCount)
               .Take(pagination.ItemCount)
               .ToListAsync();
        }
    }
}
