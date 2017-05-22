using CoreTeamProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Components
{
    public class NewsWidget: ViewComponent 
    {
        private INewsService _newsService;

        public NewsWidget(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int threshold = 4)
        {
            var news = await _newsService.GetNews(threshold);
            return View(news);
        }
    }


}
