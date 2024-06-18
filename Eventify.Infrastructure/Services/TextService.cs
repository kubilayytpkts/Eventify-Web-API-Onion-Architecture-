using Eventify.Application.Abstractions.Services;
using Eventify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Infrastructure.Services
{
    public class TextService : ITextService
    {
        public string FormatTextForEvent(IEnumerable<EventDTO> eventItem)
        {
            if (eventItem is null)
                throw new ArgumentNullException(nameof(eventItem));

            StringBuilder stringBuilder = new();

            foreach (var events in eventItem)
            {
                stringBuilder.AppendLine($"Event: {events.Title} - Location: {events.Location.City}/{events.Location.District}/{events.Location.Street} - Date: {events.Date.ToString("HH:mm - dd/MM/yyyy")} ");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
