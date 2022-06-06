using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSellWebApp.Models;
namespace TicketSellWebApp.Exporter
{
    public interface IExporter
    {
        public FileStreamResult GetFile(List<Ticket> l);
    }
}
