using Eventify.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventify.Application.Abstractions.Services.Concrete
{
    public class ExportService
    {
        private readonly ITextService _textService;
        private readonly IFileService _fileService;

        public ExportService(ITextService textService, IFileService fileService)
        {
            _textService = textService;
            _fileService = fileService;
        }

        public async Task ExportEventAsync(IEnumerable<EventDTO> events,string path)
        {
            var formattedText = _textService.FormatTextForEvent(events);
            await _fileService.SaveTextAsync(formattedText, path);
        }
    }
}
