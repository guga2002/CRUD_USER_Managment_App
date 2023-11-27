﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OBA.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mhitdde : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "action",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "action",
                table: "AspNetUsers");
        }
    }
}
