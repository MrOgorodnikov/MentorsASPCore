using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MentorsASPCore.Migrations
{
    public partial class Migrate1DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicStudentCount",
                table: "Mentors");

            migrationBuilder.AddColumn<int>(
                name: "CurrentStudentCount",
                table: "Mentors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStudentCount",
                table: "Mentors");

            migrationBuilder.AddColumn<int>(
                name: "PublicStudentCount",
                table: "Mentors",
                nullable: false,
                defaultValue: 0);
        }
    }
}
