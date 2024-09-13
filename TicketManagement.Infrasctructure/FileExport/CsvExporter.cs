using CsvHelper;
using TicketManagement.Application.Contracts.Infrastructure;
using TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;

namespace TicketManagement.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
