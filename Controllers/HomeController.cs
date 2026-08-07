using Microsoft.AspNetCore.Mvc;

namespace RoboConnect.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Discover()
        {
            return View();
        }
    }
}