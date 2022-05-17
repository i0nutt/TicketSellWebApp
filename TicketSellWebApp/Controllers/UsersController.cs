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
    public class UsersController : Controller
    {
        //Returns a page with a list of users , CRUD operations available

        public IActionResult Index()
        {
            return RedirectToAction("GetUserList","User");
        }

        private IActionResult RedirectView(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetUserList()
        {
            return View("GetUserList", _iServiceClass.GetList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();
            var user = _iServiceClass.FindById(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // returns a user creation werb form
        public IActionResult Create()
        {
            return View();
        }

        // returns a web form which enables the creation of a user 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Username,Password,jobType")] User user)
        {
            if (ModelState.IsValid)
            {
                _iServiceClass.Create(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // returns a web form which autofills with current informations, allows updating the information on the user
        public IActionResult Edit(int? id){
            if (id == null) 
                return NotFound();
            var user = _iServiceClass.FindById(id.Value);
            if (user == null)   
                return NotFound();
            else 
                return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Username,Password,jobType")] User user)
        {
            if (id != user.Id)
                return NotFound();
            if (ModelState.IsValid)
            {
                bool success = _iServiceClass.Edit(id, user);
                if (!success) return RedirectToAction(nameof(Index),"Update operation error");
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var user = _iServiceClass.FindById(id.Value);
            if (user == null)
                return NotFound();
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _iServiceClass.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public UsersController(IService<User> iserviceClass)
        {
            this._iServiceClass = iserviceClass;
        }
        private readonly IService<User> _iServiceClass;
    }
}