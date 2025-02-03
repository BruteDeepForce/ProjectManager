using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subutai.Repository.SqlRepository.Migrations.Authentication
{
    /// <inheritdoc />
    public partial class UserCurrentWorkloadDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CurrentWorkload",
                table: "AspNetUsers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "CurrentWorkload",
                table: "AspNetUsers",
                type: "real",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
