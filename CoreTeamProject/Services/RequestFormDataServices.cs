using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Services
{
    public class RequestFormDataServices : IRequestFormDataServices
    {
        public static readonly IDictionary<string, string> SubCategories =
            new Dictionary<string, string>
            {
                { "Theater","1" },
                { "Music","2" },
                { "Stand Up","3"},
                { "Karaoke", "4"},
                { "Culinary Arts","5"},
                { "Tech Panels","6" },
                { "Fitness","7"},
                { "Tech Meet-Ups","8"},
                { "Singles Mixers","9"},
                { "Trivia Night","10"},
                { "Trade Shows","11"},
                { "Food Festivals","12"},
                { "Music Festivals","13"},
                { "Games","14"},
                { "Holiday Celebrations","15"}
            };

        public List<SelectListItem> GetSubCategories()
        {
            return new SelectList(SubCategories, "Value", "Key").ToList();
        }
    }
}
