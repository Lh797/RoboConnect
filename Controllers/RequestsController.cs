using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboConnect.Data;
using RoboConnect.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RoboConnect.Controllers
{
    public class RequestsController : Controller
    {
        private readonly RoboConnectDbContext _context;

        public RequestsController(RoboConnectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RobotRequestFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RobotRequestFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new RobotRequest
            {
                RequestTitle = model.RequestTitle,
                RobotType = model.RobotType,
                UseCaseCategory = model.UseCaseCategory,
                Description = model.Description,
                FeaturesSummary = string.Join(", ", model.GetSelectedFeatures()),
                BudgetRange = model.BudgetRange,
                PreferredTimeline = model.PreferredTimeline,
                ContactPreference = model.ContactPreference,
                SubmittedAt = DateTime.Now
            };

            _context.RobotRequests.Add(entity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Your robotic request has been submitted successfully.";
            return RedirectToAction(nameof(Create));
        }

        [HttpGet]
        public async Task<IActionResult> MyRequests()
        {
            var requests = await _context.RobotRequests
                .OrderByDescending(r => r.SubmittedAt)
                .ToListAsync();

            return View(requests);
        }
    }
}