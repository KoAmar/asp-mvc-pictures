using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationMVC.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Topics",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Topics", x => x.Id); });

            migrationBuilder.CreateTable(
                "Posts",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    CreatorLogin = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(),
                    TopicOfPostId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        "FK_Posts_Topics_TopicOfPostId",
                        x => x.TopicOfPostId,
                        "Topics",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Posts_TopicOfPostId",
                "Posts",
                "TopicOfPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Posts");

            migrationBuilder.DropTable(
                "Topics");
        }
    }
}