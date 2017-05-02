using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CoreTeamProject.Models;

namespace CoreTeamProject.Data
{
    public class EventContext : DbContext

    {
        public EventContext(DbContextOptions<EventContext>option) : base(option)
        {
        }

        public DbSet<Categories> Category { get; set; }
        
        public DbSet<SubCategories> SubCategory { get; set; }

        public DbSet<Events> Event { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Categories>().ToTable("Category");
            builder.Entity<SubCategories>().ToTable("Subcategory");
            builder.Entity<Events>().ToTable("Event");
        }
    }
}
