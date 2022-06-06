using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketSellWebApp.Data;
using TicketSellWebApp.Models;
using TicketSellWebApp.Services;

namespace TicketSellWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsAPIController : ControllerBase
    {
        // GET: api/TicketsAPI
        [HttpGet]
        public ActionResult<IEnumerable<Ticket>> GetTicket()
        {
            return _iServiceClass.GetList();
        }

        // GET: api/TicketsAPI/5
        [HttpGet("{id}")]
        public ActionResult<Ticket> GetTicket(int id)
        {
            var ticket = _iServiceClass.FindById(id);

            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        [HttpGet("ByShow/{showNumber}")]
        public ActionResult<List<Ticket>> GetTicketsByShow(int showNumber)
        {
            var ticketList = _iServiceClass.FindByShow(showNumber);

            if (ticketList.Count == 0)
            {
                return NotFound();
            }
            return ticketList;
        }

        // POST: api/TicketsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Ticket> PostTicket(Ticket ticket)
        {
            _iServiceClass.Create(ticket);

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/TicketsAPI/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            _iServiceClass.Delete(id);

            return NoContent();
        }
        public TicketsAPIController(ITicketService<Ticket> iserviceClass)
        {
            this._iServiceClass = iserviceClass;
        }
        private readonly ITicketService<Ticket> _iServiceClass;
    }
}
