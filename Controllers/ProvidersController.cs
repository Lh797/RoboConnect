using Microsoft.AspNetCore.Mvc;
using RoboConnect.Services;
using System;
using System.Linq;

namespace RoboConnect.Controllers
{
    public class ProvidersController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? type)
        {
            var providers = AppDataStore.Providers.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(type) && !string.Equals(type, "All", StringComparison.OrdinalIgnoreCase))
            {
                providers = providers.Where(p =>
                    string.Equals(p.ProviderType, type, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.SelectedType = string.IsNullOrWhiteSpace(type) ? "All" : type;

            return View(providers.ToList());
        }
    }
}