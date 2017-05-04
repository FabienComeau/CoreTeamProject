using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreTeamProject.Data;

namespace CoreTeamProject.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20170503173635_CreateEvent")]
    partial class CreateEvent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreTeamProject.Models.Categories", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("categoryTitle");

                    b.HasKey("categoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("CoreTeamProject.Models.Events", b =>
                {
                    b.Property<int>("eventID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("eventCost")
                        .HasColumnType("money");

                    b.Property<DateTime>("eventDate");

                    b.Property<string>("eventDescription")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("eventEmail");

                    b.Property<string>("eventLocation")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("eventName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("eventPhoneNumber");

                    b.Property<DateTime>("eventTime");

                    b.Property<int>("subCategoryID");

                    b.HasKey("eventID");

                    b.HasIndex("subCategoryID");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("CoreTeamProject.Models.SubCategories", b =>
                {
                    b.Property<int>("subCategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("categoryID");

                    b.Property<string>("subCategoryTitle");

                    b.HasKey("subCategoryID");

                    b.HasIndex("categoryID");

                    b.ToTable("Subcategory");
                });

            modelBuilder.Entity("CoreTeamProject.Models.Events", b =>
                {
                    b.HasOne("CoreTeamProject.Models.SubCategories", "Subcategory")
                        .WithMany("Event")
                        .HasForeignKey("subCategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CoreTeamProject.Models.SubCategories", b =>
                {
                    b.HasOne("CoreTeamProject.Models.Categories", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
