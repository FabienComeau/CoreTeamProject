using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreTeamProject.Migrations
{
    public partial class EventFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "eventDescription",
                table: "Event",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Event",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Event",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "categoryID",
                table: "Category",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Event");

            migrationBuilder.AlterColumn<string>(
                name: "eventDescription",
                table: "Event",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2000);

            migrationBuilder.AlterColumn<int>(
                name: "categoryID",
                table: "Category",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
        }
    }
}
