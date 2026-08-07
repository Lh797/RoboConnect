using Microsoft.EntityFrameworkCore;
using RoboConnect.Models;

namespace RoboConnect.Data
{
    public class RoboConnectDbContext : DbContext
    {
        public RoboConnectDbContext(DbContextOptions<RoboConnectDbContext> options)
            : base(options)
        {
        }

        public DbSet<RobotRequest> RobotRequests => Set<RobotRequest>();
        public DbSet<DiscussionPost> DiscussionPosts => Set<DiscussionPost>();
    }
}