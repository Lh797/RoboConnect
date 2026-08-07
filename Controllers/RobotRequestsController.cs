using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboConnect.Data;
using RoboConnect.Models;

namespace RoboConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RobotRequestsController : ControllerBase
    {
        private readonly RoboConnectDbContext _context;

        public RobotRequestsController(RoboConnectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RobotRequest>>> GetAll()
        {
            return await _context.RobotRequests.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RobotRequest>> GetById(int id)
        {
            var robotRequest = await _context.RobotRequests.FindAsync(id);

            if (robotRequest == null)
                return NotFound();

            return robotRequest;
        }

        [HttpPost]
        public async Task<ActionResult<RobotRequest>> Create(RobotRequest robotRequest)
        {
            _context.RobotRequests.Add(robotRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = robotRequest.Id }, robotRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RobotRequest robotRequest)
        {
            if (id != robotRequest.Id)
                return BadRequest();

            var existing = await _context.RobotRequests.FindAsync(id);

            if (existing == null)
                return NotFound();

            existing.RequestTitle = robotRequest.RequestTitle;
            existing.RobotType = robotRequest.RobotType;
            existing.UseCaseCategory = robotRequest.UseCaseCategory;
            existing.Description = robotRequest.Description;
            existing.FeaturesSummary = robotRequest.FeaturesSummary;
            existing.BudgetRange = robotRequest.BudgetRange;
            existing.PreferredTimeline = robotRequest.PreferredTimeline;
            existing.ContactPreference = robotRequest.ContactPreference;
            existing.SubmittedAt = robotRequest.SubmittedAt;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var robotRequest = await _context.RobotRequests.FindAsync(id);

            if (robotRequest == null)
                return NotFound();

            _context.RobotRequests.Remove(robotRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}