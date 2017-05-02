using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CoreTeamProject.Data;

namespace CoreTeamProject.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreTeamProject.Models.Categories", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("categoryTitle");

                    b.HasKey("categoryID");

                    b.ToTable("Category");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Categories");
                });

            modelBuilder.Entity("CoreTeamProject.Models.SubCategories", b =>
                {
                    b.HasBaseType("CoreTeamProject.Models.Categories");

                    b.Property<int>("subCategoryID");

                    b.Property<string>("subCategoryTitle");

                    b.ToTable("Subcategory");

                    b.HasDiscriminator().HasValue("SubCategories");
                });

            modelBuilder.Entity("CoreTeamProject.Models.Events", b =>
                {
                    b.HasBaseType("CoreTeamProject.Models.SubCategories");

                    b.Property<double>("eventCost");

                    b.Property<DateTime>("eventDate");

                    b.Property<string>("eventDescription");

                    b.Property<string>("eventEmail");

                    b.Property<int>("eventID");

                    b.Property<string>("eventLocation");

                    b.Property<string>("eventName");

                    b.Property<string>("eventPhoneNumber");

                    b.ToTable("Event");

                    b.HasDiscriminator().HasValue("Events");
                });
        }
    }
}
