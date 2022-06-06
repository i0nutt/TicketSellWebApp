using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;
using System.IO;
using Microsoft.Net.Http.Headers;

namespace TicketSellWebApp.Exporter
{
    public class CsvExporter : IExporter
    {
        public FileStreamResult GetFile(List<Ticket> l)
        {
            GenerateFile(l);
            var stream = new MemoryStream(System.IO.File.ReadAllBytes(path));
            ditchFile();
            return new FileStreamResult(stream, new MediaTypeHeaderValue("text/csv"))
            {
                FileDownloadName = path
            };
        }
        private void GenerateFile(List<Ticket> list)
        {
            System.Text.StringBuilder sb = new();
            sb.Append("Id" + ',');
            sb.Append("Show Number" + ',');
            sb.Append("Row Number" + ',');
            sb.Append("Column Number" + ',');
            sb.Append("\r\n");
            foreach (Ticket t in list)
            {
                sb.Append(t.Id.ToString() + ',');
                sb.Append(t.ShowNumber.ToString() + ',');
                sb.Append(t.RowNumber.ToString() + ',');
                sb.Append(t.ColumnNumber.ToString() + ',');
                sb.Append("\r\n");
            }
            File.WriteAllText("Tickets.csv", sb.ToString());
        }
        private void ditchFile()
        {
            File.Delete(path);
        }
        private static string path = "Tickets.csv";
    }
}
