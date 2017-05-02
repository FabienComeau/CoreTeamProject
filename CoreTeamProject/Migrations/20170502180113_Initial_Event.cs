using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreTeamProject.Migrations
{
    public partial class Initial_Event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    categoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    categoryTitle = table.Column<string>(nullable: true),
                    eventCost = table.Column<double>(nullable: true),
                    eventDate = table.Column<DateTime>(nullable: true),
                    eventDescription = table.Column<string>(nullable: true),
                    eventEmail = table.Column<string>(nullable: true),
                    eventID = table.Column<int>(nullable: true),
                    eventLocation = table.Column<string>(nullable: true),
                    eventName = table.Column<string>(nullable: true),
                    eventPhoneNumber = table.Column<string>(nullable: true),
                    subCategoryID = table.Column<int>(nullable: true),
                    subCategoryTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.categoryID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
