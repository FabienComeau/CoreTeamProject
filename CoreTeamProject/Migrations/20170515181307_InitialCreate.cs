using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreTeamProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryID = table.Column<int>(nullable: false),
                    categoryTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryID);
                });

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
                    Facebook = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    eventCost = table.Column<decimal>(type: "money", nullable: false),
                    eventDate = table.Column<DateTime>(nullable: false),
                    eventDescription = table.Column<string>(maxLength: 2000, nullable: false),
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

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
