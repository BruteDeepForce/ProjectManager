using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subutai.Repository.SqlRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_UserEntity_UserId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "UserNumber",
                table: "Tasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Tasks",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserNumber",
                table: "Tasks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false),
                    CompleteTaskTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CompletedProjects = table.Column<float>(type: "real", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CurrentWorkload = table.Column<float>(type: "real", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    ExpectTaskComplete = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExperienceYears = table.Column<float>(type: "real", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PerformanceRating = table.Column<float>(type: "real", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_UserEntity_UserId",
                table: "Tasks",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id");
        }
    }
}
