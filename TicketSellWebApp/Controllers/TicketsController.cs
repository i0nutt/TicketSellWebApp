using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSellWebApp.Data;
using TicketSellWebApp.Exporter;
using TicketSellWebApp.Models;
using TicketSellWebApp.Services;

namespace TicketSellWebApp.Controllers
{
    public class TicketsController : Controller
    {
        // GET: Tickets
        public IActionResult Index()
        {
            return RedirectToAction("UserLoggedIn","Login");
        }
        public IActionResult GetTicketList()
        {
            return View(_iServiceClass.GetList());
        }
        // GET: Tickets/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = _iServiceClass.FindById(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,ShowNumber,RowNumber,ColumnNumber")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _iServiceClass.Create(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _iServiceClass.FindById(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ShowNumber,RowNumber,ColumnNumber")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (!_iServiceClass.Edit(id, ticket))
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = _iServiceClass.FindById(id.Value); 
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _iServiceClass.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet, ActionName("GenerateSoldTicketsFile")]
        public IActionResult GenerateSoldTicketsFile(String format)
        {
            //format = "pdf";
            IExporter myExporter = ExporterFactory.GenerateExporter(format);
            return myExporter.GetFile(_iServiceClass.GetList());
        }
        public TicketsController(ITicketService<Ticket> iserviceClass)
        {
            this._iServiceClass = iserviceClass;
        }
        private readonly ITicketService<Ticket> _iServiceClass;
    }
}
