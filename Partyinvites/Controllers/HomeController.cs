
using Microsoft.AspNetCore.Mvc;

namespace Partyinvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("MyView");
        }
    }
}
