using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboConnect.Data;
using RoboConnect.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RoboConnect.Controllers
{
    public class HubController : Controller
    {
        private readonly RoboConnectDbContext _context;

        public HubController(RoboConnectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? topic)
        {
            var query = _context.DiscussionPosts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(topic) && !string.Equals(topic, "All", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(p => p.TopicTag == topic);
            }

            var posts = await query
                .OrderByDescending(p => p.PostedAt)
                .Select(p => new DiscussionPostViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    AuthorName = p.AuthorName,
                    TopicTag = p.TopicTag,
                    LikeCount = p.LikeCount,
                    PostedAt = p.PostedAt
                })
                .ToListAsync();

            ViewBag.SelectedTopic = string.IsNullOrWhiteSpace(topic) ? "All" : topic;
            ViewBag.TotalPosts = await _context.DiscussionPosts.CountAsync();

            return View(posts);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost(DiscussionPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var fallbackQuery = _context.DiscussionPosts.AsQueryable();

                if (!string.IsNullOrWhiteSpace(model.TopicTag) && !string.Equals(model.TopicTag, "All", StringComparison.OrdinalIgnoreCase))
                {
                    fallbackQuery = fallbackQuery.Where(p => p.TopicTag == model.TopicTag);
                }

                var fallbackPosts = await fallbackQuery
                    .OrderByDescending(p => p.PostedAt)
                    .Select(p => new DiscussionPostViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Content = p.Content,
                        AuthorName = p.AuthorName,
                        TopicTag = p.TopicTag,
                        LikeCount = p.LikeCount,
                        PostedAt = p.PostedAt
                    })
                    .ToListAsync();

                ViewBag.SelectedTopic = string.IsNullOrWhiteSpace(model.TopicTag) ? "All" : model.TopicTag;
                ViewBag.TotalPosts = await _context.DiscussionPosts.CountAsync();

                return View("Index", fallbackPosts);
            }

            var entity = new DiscussionPost
            {
                Title = model.Title,
                Content = model.Content,
                AuthorName = model.AuthorName,
                TopicTag = model.TopicTag,
                LikeCount = 0,
                PostedAt = DateTime.Now
            };

            _context.DiscussionPosts.Add(entity);
            await _context.SaveChangesAsync();

            TempData["HubSuccessMessage"] = "Your discussion post has been published.";
            return RedirectToAction(nameof(Index), new { topic = model.TopicTag });
        }
    }
}