using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreTeamProject.Data;
using CoreTeamProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using CoreTeamProject.Helpers;

namespace CoreTeamProject.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventContext _context;
        private IHostingEnvironment _hostingEnv;

        public EventsController(EventContext context, IHostingEnvironment env)
        {
            _context = context;
            _hostingEnv = env;
        }
        

        // GET: Events
        public async Task<IActionResult> Index(int? id, int? page)
        {
            var eventContext = _context.Event
                .Include(e => e.Subcategory)/*.ThenInclude(c => c.Category)*/
                .Where(c => c.Subcategory.Category.categoryID == id);
            //return View(await eventContext.ToListAsync());
            int pageSize = 1;
            return View(await PaginatedList<Events>.CreateAsync(eventContext, page ?? 1, pageSize));
            //select * from event where subCategoryID in(select subCategoryID from Subcategory where categoryID = 1)
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Event
                .Include(e => e.Subcategory)
                .SingleOrDefaultAsync(m => m.eventID == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            ViewData["subCategoryID"] = new SelectList(_context.SubCategory, "subCategoryID", "subCategoryID");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("eventID,eventName,eventDescription,eventDate,eventTime,eventLocation,eventEmail,eventPhoneNumber,eventCost,subCategoryID")] IList<IFormFile> files, Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();

                foreach (var file in files)
                {
                    // rename the file to userId.jpg
                    var filename = events.eventID + System.IO.Path.GetExtension(file.FileName);
                    // tag on the path where we want to upload the image 
                    filename = _hostingEnv.WebRootPath + $@"\img\events\{filename}";

                    using (System.IO.FileStream fs = System.IO.File.Create(filename))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                }


                return RedirectToAction("Index");

            }
            ViewData["subCategoryID"] = new SelectList(_context.SubCategory, "subCategoryID", "subCategoryID", events.subCategoryID);
            return View(events);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Event.SingleOrDefaultAsync(m => m.eventID == id);
            if (events == null)
            {
                return NotFound();
            }
            ViewData["subCategoryID"] = new SelectList(_context.SubCategory, "subCategoryID", "subCategoryID", events.subCategoryID);
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("eventID,eventName,eventDescription,eventDate,eventTime,eventLocation,eventEmail,eventPhoneNumber,eventCost,subCategoryID")] Events events)
        {
            if (id != events.eventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventsExists(events.eventID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Listing");
            }
            ViewData["subCategoryID"] = new SelectList(_context.SubCategory, "subCategoryID", "subCategoryID", events.subCategoryID);
            return View(events);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Event
                .Include(e => e.Subcategory)
                .SingleOrDefaultAsync(m => m.eventID == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Event.SingleOrDefaultAsync(m => m.eventID == id);
            _context.Event.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Browser(int? SelectedDepartment)
        {
            return View();
        }

        public async Task<IActionResult> Listing(int? SelectedDepartment)
        {
            var events = await _context.Event.ToListAsync();

            return View(events);
        }

        public async Task<IActionResult> Search(string search)
        {
            var events = _context.Event.Where(e => e.eventName.Contains(search) || e.eventDescription.Contains(search) || e.eventLocation.Contains(search));
            ViewData["search"] = search;
            return View(await events.ToListAsync());
        }


        private bool EventsExists(int id)
        {
            return _context.Event.Any(e => e.eventID == id);
        }

        private IQueryable<Events> GetUpcomingEvents(int threshold)
        {

            IQueryable<Events> upcoming = _context.Event.Where(e => e.eventDate > DateTime.Today).OrderBy(e => e.eventName);
            return upcoming;
        }


    }
}
