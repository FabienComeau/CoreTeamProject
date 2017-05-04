using CoreTeamProject.Data;
using System;
using System.Linq;

namespace CoreTeamProject.Models
{
    //mwilliams: Part 2 -  Create the Data Model
    //Add code to initialize the database with test data

    // Code will cause a database to be created when needed and loads test data into the new database
    public static class DbInitializer
    {
        public static void Initialize(EventContext context)
        {
            //context.Database.EnsureCreated();// EnsureCreated method will automatically create the database.
            //Later we will handle model changes by using Code First Migrations to change the database schema 
            //instead of dropping and re-creating the database
            //https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/complex-data-model#seed-the-database-with-test-data

            //================================================== Categories ============================================//
            // Look for any students.
            //if (context.Category.Any())
            //{
            //    return;   // DB has been seeded
            //}

            //var categories = new Categories[]
            //{
            //new Categories{categoryTitle="Festivals"},
            //new Categories{categoryTitle="Self Betterment"},
            //new Categories{categoryTitle="Entertainment"},
            //new Categories{categoryTitle="Social"},
            //};
            //foreach (Categories s in categories)
            //{
            //    context.Category.Add(s);
            //}
            //context.SaveChanges();


            ////================================================== Sub Categories ============================================//
            //// Look for any students.
            //if (context.SubCategory.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var subcategories = new SubCategories[]
            {
                new SubCategories { subCategoryTitle = "Theater", categoryID = 3 },
            new SubCategories { subCategoryTitle = "Music", categoryID = 3 },
            new SubCategories { subCategoryTitle = "Stand Up", categoryID = 3 },
            new SubCategories { subCategoryTitle = "Karaoke", categoryID = 3 },
            new SubCategories { subCategoryTitle = "Culinary Arts", categoryID = 2 },
            new SubCategories { subCategoryTitle = "Tech Pannels", categoryID = 2 },
            new SubCategories { subCategoryTitle = "Self-Help", categoryID = 2 },
            new SubCategories { subCategoryTitle = "Fitness", categoryID = 2 },
            new SubCategories { subCategoryTitle = "Tech Meet-Up", categoryID = 4 },
            new SubCategories { subCategoryTitle = "Single Mixer", categoryID = 4 },
            new SubCategories { subCategoryTitle = "Trivia Night", categoryID = 4 },
            new SubCategories { subCategoryTitle = "Trade Show", categoryID = 1 },
            new SubCategories { subCategoryTitle = "Food Festival", categoryID = 1 },
            new SubCategories { subCategoryTitle = "Music Festival", categoryID = 1 },
            new SubCategories { subCategoryTitle = "Games", categoryID = 1 },
            new SubCategories { subCategoryTitle = "Holiday Celebrations", categoryID = 4 },
            };
            //foreach (SubCategories s in subcategories)
            //{
            //    context.SubCategory.Add(s);
            //}
            //context.SaveChanges();


            var events = new Events[]
            {
            new Events{eventName="Moncton Highland Games and Scottish Festival", eventDescription="Moncton Highland Games & Scottish Festival is a",
                eventDate =DateTime.Parse("Sunday, June 11, 2017"), eventTime=DateTime.Parse("11:00 AM"),eventLocation="Moncton, NB",
            eventCost=60, subCategoryID = subcategories.Single(s=>s.subCategoryTitle == "Games").subCategoryID},
            };
            foreach (Events s in events)
            {
                context.Event.Add(s);
            }
            context.SaveChanges();

        }
    }
}