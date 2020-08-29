using System;
using Microsoft.AspNetCore.Mvc;

namespace Partyinvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Мorning" : "Good Afternoon";
            return View("MyView");
        }

        public ViewResult RsvpForm()
        {
            return View();
        }
    }
}
