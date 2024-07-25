﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");
        }
    }
}
