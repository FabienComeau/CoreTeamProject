using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreTeamProject.Migrations
{
    public partial class CreateEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventCost",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventDescription",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventEmail",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventLocation",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventName",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "eventPhoneNumber",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "subCategoryID",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "subCategoryTitle",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    subCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    categoryID = table.Column<int>(nullable: false),
                    subCategoryTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.subCategoryID);
                    table.ForeignKey(
                        name: "FK_Subcategory_Category_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Category",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    eventID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eventCost = table.Column<decimal>(type: "money", nullable: false),
                    eventDate = table.Column<DateTime>(nullable: false),
                    eventDescription = table.Column<string>(maxLength: 500, nullable: false),
                    eventEmail = table.Column<string>(nullable: true),
                    eventLocation = table.Column<string>(maxLength: 100, nullable: false),
                    eventName = table.Column<string>(maxLength: 200, nullable: false),
                    eventPhoneNumber = table.Column<string>(nullable: true),
                    eventTime = table.Column<DateTime>(nullable: false),
                    subCategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.eventID);
                    table.ForeignKey(
                        name: "FK_Event_Subcategory_subCategoryID",
                        column: x => x.subCategoryID,
                        principalTable: "Subcategory",
                        principalColumn: "subCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_subCategoryID",
                table: "Event",
                column: "subCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategory_categoryID",
                table: "Subcategory",
                column: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Category",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "eventCost",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "eventDate",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eventDescription",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eventEmail",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "eventID",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eventLocation",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eventName",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eventPhoneNumber",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subCategoryID",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "subCategoryTitle",
                table: "Category",
                nullable: true);
        }
    }
}
