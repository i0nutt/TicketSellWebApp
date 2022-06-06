using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;

namespace TicketSellWebApp.Exporter
{
    public class JsonExporter : IExporter
    {
        public FileStreamResult GetFile(List<Ticket> l)
        {
            GenerateFile(l);
            var stream = new MemoryStream(System.IO.File.ReadAllBytes(path));
            ditchFile();
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/json"))
            {
                FileDownloadName = path
            };
        }
        private void GenerateFile(List<Ticket> l)
        {
            var jsonString = JsonConvert.SerializeObject(l, Formatting.Indented, _options);
            File.WriteAllText(path, jsonString);
        }
        private void ditchFile()
        {
            File.Delete(path);
        }
        private static string path = "Tickets.json";
        private static readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore };
    }
}
