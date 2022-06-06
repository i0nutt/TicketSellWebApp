using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSellWebApp.Exporter
{
    public class ExporterFactory
    {
        public static IExporter GenerateExporter(String s)
        {
            return s switch
            {
                "csv" => new CsvExporter(),
                "json" => new JsonExporter(),
                "pdf" => new PdfExporter(),
                _ => null,
            };
        }
    }
}
