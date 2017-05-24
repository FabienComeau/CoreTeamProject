
using CoreTeamProject.Data;
using CoreTeamProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Services
{
    public class NewsService : INewsService 
    {

        private readonly EventContext _context;

        public NewsService(EventContext context)
        {
            _context = context;

        }
       


        public Task<IEnumerable<Events>> GetNews(int threshold)
        {
            var _news = _context.Event.ToList();
            return Task.FromResult<IEnumerable<Events>>(_news.OrderBy(x => x.eventDate).Take(threshold).ToList());
        }
    }

}


