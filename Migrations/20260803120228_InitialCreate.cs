using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoboConnect.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscussionPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TopicTag = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscussionPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RobotRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RobotType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UseCaseCategory = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FeaturesSummary = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BudgetRange = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PreferredTimeline = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ContactPreference = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobotRequests", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscussionPosts");

            migrationBuilder.DropTable(
                name: "RobotRequests");
        }
    }
}
