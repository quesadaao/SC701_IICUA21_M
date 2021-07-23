using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FrontEnd.W.Models;

namespace FrontEnd.W.Controllers
{
    public class GroupUpdatesController : Controller
    {
        private readonly SocialGoalContext _context;

        public GroupUpdatesController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: GroupUpdates
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroupUpdates.ToListAsync());
        }

        // GET: GroupUpdates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUpdates = await _context.GroupUpdates
                .FirstOrDefaultAsync(m => m.GroupUpdateId == id);
            if (groupUpdates == null)
            {
                return NotFound();
            }

            return View(groupUpdates);
        }

        // GET: GroupUpdates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupUpdates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupUpdateId,Updatemsg,Status,GroupGoalId,UpdateDate")] GroupUpdates groupUpdates)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupUpdates);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupUpdates);
        }

        // GET: GroupUpdates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUpdates = await _context.GroupUpdates.FindAsync(id);
            if (groupUpdates == null)
            {
                return NotFound();
            }
            return View(groupUpdates);
        }

        // POST: GroupUpdates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupUpdateId,Updatemsg,Status,GroupGoalId,UpdateDate")] GroupUpdates groupUpdates)
        {
            if (id != groupUpdates.GroupUpdateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupUpdates);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupUpdatesExists(groupUpdates.GroupUpdateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(groupUpdates);
        }

        // GET: GroupUpdates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupUpdates = await _context.GroupUpdates
                .FirstOrDefaultAsync(m => m.GroupUpdateId == id);
            if (groupUpdates == null)
            {
                return NotFound();
            }

            return View(groupUpdates);
        }

        // POST: GroupUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupUpdates = await _context.GroupUpdates.FindAsync(id);
            _context.GroupUpdates.Remove(groupUpdates);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupUpdatesExists(int id)
        {
            return _context.GroupUpdates.Any(e => e.GroupUpdateId == id);
        }
    }
}
