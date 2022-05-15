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
    public class LoginController : Controller
    { 
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProcessLogin(User user)
        {
            var u = _iServiceClass.FindByInfo(user);
            if(u == null)
            {
                ViewBag.Message = "Invalid username or password";
                return View("LoginFailure");
            }
            else
            {
                _iCookieServiceClass.SetCookie<User>(Response,"User",u);
                return RedirectToAction("UserLoggedIn","Login");
            }
        }
        public IActionResult UserLoggedIn()
        {
            return View("UserLoggedIn");
        }
        public IActionResult LogOut()
        {
            _iCookieServiceClass.SetCookie<User>(Response, "User", null);
            return RedirectToAction("Index", "Login");
        }
        public LoginController(IService<User> iserviceClass, ICookieService _iCookieServiceClass)
        {
            this._iServiceClass = iserviceClass;
            this._iCookieServiceClass = _iCookieServiceClass;
        }
        private readonly IService<User> _iServiceClass;
        private readonly ICookieService _iCookieServiceClass;
    }
}
