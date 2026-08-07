using Microsoft.AspNetCore.Mvc;
using RoboConnect.Models;
using RoboConnect.Services;
using System;
using System.Linq;

namespace RoboConnect.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet]
        public IActionResult Index(string? room)
        {
            var messages = AppDataStore.Messages.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(room) && !string.Equals(room, "All", StringComparison.OrdinalIgnoreCase))
            {
                messages = messages.Where(m =>
                    string.Equals(m.Room, room, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.SelectedRoom = string.IsNullOrWhiteSpace(room) ? "All" : room;
            ViewBag.TotalCount = AppDataStore.Messages.Count;

            return View(messages.OrderBy(m => m.SentAt).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(ChatMessageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SelectedRoom = string.IsNullOrWhiteSpace(model.Room) ? "All" : model.Room;
                ViewBag.TotalCount = AppDataStore.Messages.Count;

                var fallback = AppDataStore.Messages.AsEnumerable();

                if (!string.IsNullOrWhiteSpace(model.Room))
                {
                    fallback = fallback.Where(m =>
                        string.Equals(m.Room, model.Room, StringComparison.OrdinalIgnoreCase));
                }

                return View("Index", fallback.OrderBy(m => m.SentAt).ToList());
            }

            model.Id = AppDataStore.Messages.Count + 1;
            model.SentAt = DateTime.Now;
            model.IsCurrentUser = true;

            AppDataStore.Messages.Add(model);

            TempData["ChatSuccessMessage"] = "Your message has been sent.";
            return RedirectToAction(nameof(Index), new { room = model.Room });
        }
    }
}