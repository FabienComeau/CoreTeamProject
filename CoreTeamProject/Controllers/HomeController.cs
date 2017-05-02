using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreTeamProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        //fcomeau: inputed the browser
        public IActionResult Browser()
        {
            ViewData["Message"] = "Your browser page.";

            return View();
        }

        //fcomeau: inputed the events
        public IActionResult Events()
        {
            ViewData["Message"] = "Your events page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
