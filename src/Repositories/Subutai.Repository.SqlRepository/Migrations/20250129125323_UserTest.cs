﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Subutai.Repository.SqlRepository.Migrations
{
    /// <inheritdoc />
    public partial class UserTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UniqueId",
                table: "Users",
                type: "uuid",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueId",
                table: "Users");
        }
    }
}
