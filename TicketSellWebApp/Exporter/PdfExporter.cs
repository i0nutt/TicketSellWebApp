using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;
using Aspose.Cells;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Net.Http.Headers;

namespace TicketSellWebApp.Exporter
{
    public class PdfExporter : IExporter
    {
        public FileStreamResult GetFile(List<Ticket> l)
        {
            GenerateFile(l);
            var workbook = new Workbook(path);
            ditchFile(path);
            workbook.Save(pdfPath);
            var stream = new MemoryStream(System.IO.File.ReadAllBytes(pdfPath));
            ditchFile(pdfPath);
            return new FileStreamResult(stream, new MediaTypeHeaderValue("application/pdf"))
            {
                FileDownloadName = pdfPath
            };
        }
        private void GenerateFile(List<Ticket> l)
        {
            var jsonString = JsonConvert.SerializeObject(l, Formatting.Indented, _options);
            File.WriteAllText(path, jsonString);
        }
        private void ditchFile(string path)
        {
            File.Delete(path);
        }
        private static string path = "Tickets.json";
        private static string pdfPath = "Tickets.pdf";
        private static readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore };
    }
}
