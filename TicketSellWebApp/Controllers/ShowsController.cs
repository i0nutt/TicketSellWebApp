using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketSellWebApp.Data;
using TicketSellWebApp.Models;
using TicketSellWebApp.Services;

namespace TicketSellWebApp.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public IActionResult Index()
        {
            return RedirectToAction("GetShowList", "Show");
        }
        public IActionResult GetShowList()
        {
            return View("GetShowList", _iServiceClass.GetList());
        }

        // GET: Shows/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var user = _iServiceClass.FindById(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // GET: Shows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Cast,Actors,PremierDate,NumberOfTickets")] Show show)
        {
            if (ModelState.IsValid)
            {
                _iServiceClass.Create(show);
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }
        // GET: Shows/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var show = _iServiceClass.FindById(id.Value);
            if (show == null)
                return NotFound();
            else
                return View(show);
        }

        // POST: Shows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Cast,Actors,PremierDate,NumberOfTickets")] Show show)
        {
            if (id != show.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                bool success = _iServiceClass.Edit(id, show);
                if (!success) return RedirectToAction(nameof(Index), "Update operation error");
                return RedirectToAction(nameof(Index));
            }
            return View(show);
        }

        // GET: Shows/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var show = _iServiceClass.FindById(id.Value);
            if (show == null)
                return NotFound();
            return View(show);
        }

        // POST: Shows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _iServiceClass.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ShowsController(IService<Show> iserviceClass)
        {
            this._iServiceClass = iserviceClass;
        }
        private readonly IService<Show> _iServiceClass;
    }
}
