using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subutai.Repository.SqlRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskEfficiency",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "TaskEfficiency",
                table: "Users",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UniqueId",
                table: "Users",
                type: "uuid",
                nullable: true);
        }
    }
}
