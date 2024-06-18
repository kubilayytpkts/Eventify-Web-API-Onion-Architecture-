using Eventify.Application.Abstractions.Services;
using Eventify.Application.Abstractions.Services.Concrete;
using Eventify.Application.DTOs;
using Eventify.Application.RequestParameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ExportService _exportService;

        public EventController(IEventService eventService, ExportService exportService)
        {
            _eventService = eventService;
            _exportService = exportService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllEvents([FromQuery]Pagination pagination )
        {
            var value = await _eventService.GetAllEventAsync(pagination);
            
            return Ok(value);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateEvent(CreateEventDTO eventDto)
        {
            await _eventService.CreateEventAsync(eventDto);
            return Ok("İşlem başarılı");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ExportEvents([FromQuery]Pagination pagination,string path)
        {
            var events = await _eventService.GetAllEventAsync(pagination);
            var exports = _exportService.ExportEventAsync(events,path);

            return Ok("İşlem Başarılı");
        }
    }
}
