using CoreTeamProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Services
{
    public class NewsService : INewsService
    {
        static List<Events> _news;

        static NewsService()
        {
            //_news = GetUpcomingEvents();

            _news = new List<Events>();
        }


        public Task<IEnumerable<Events>> GetNews(int threshold)
        {
            return Task.FromResult<IEnumerable<Events>>(_news.OrderBy(x => x.eventID).Take(threshold).ToList());
        }
    }

}


