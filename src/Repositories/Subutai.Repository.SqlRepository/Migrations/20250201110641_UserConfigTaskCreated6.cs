using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subutai.Repository.SqlRepository.Migrations
{
    /// <inheritdoc />
    public partial class UserConfigTaskCreated6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Tasks",
                newName: "UserNumb");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserNumb",
                table: "Tasks",
                newName: "UserId");
        }
    }
}
