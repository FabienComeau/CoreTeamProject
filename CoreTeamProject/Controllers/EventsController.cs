using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreTeamProject.Data;
using CoreTeamProject.Models;

namespace CoreTeamProject.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventContext _context;

        public EventsController(EventContext context)
        {
            _context = context;    
        }
        

        // GET: Events
        public async Task<IActionResult> Index(int? id)
        {
            var eventContext = _context.Event
                .Include(e => e.Subcategory)/*.ThenInclude(c => c.Category)*/
                .Where(c => c.Subcategory.Category.categoryID == id);
            return View(await eventContext.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("eventID,eventName,eventDescription,eventDate,eventTime,eventLocation,eventEmail,eventPhoneNumber,eventCost,subCategoryID")] Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
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
                return RedirectToAction("Index");
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

        public async Task<IActionResult> Browser(int? SelectedDepartment)
        {
            return View();
        }

        public async Task<IActionResult> Listing(int? SelectedDepartment)
        {
            var events = await _context.Event.ToListAsync();

            return View(events);
        }


        private bool EventsExists(int id)
        {
            return _context.Event.Any(e => e.eventID == id);
        }
    }
}
