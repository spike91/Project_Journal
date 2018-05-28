using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Project.DataBase.Migrations
{
    public partial class AddImageToJournal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Journals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Concretejournals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Concretejournals");
        }
    }
}
