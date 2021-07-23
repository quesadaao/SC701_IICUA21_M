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
    public class GroupRequestsController : Controller
    {
        private readonly SocialGoalContext _context;

        public GroupRequestsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: GroupRequests
        public async Task<IActionResult> Index()
        {
            var socialGoalContext = _context.GroupRequests.Include(g => g.Group).Include(g => g.User);
            return View(await socialGoalContext.ToListAsync());
        }

        // GET: GroupRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupRequests = await _context.GroupRequests
                .Include(g => g.Group)
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GroupRequestId == id);
            if (groupRequests == null)
            {
                return NotFound();
            }

            return View(groupRequests);
        }

        // GET: GroupRequests/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: GroupRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupRequestId,GroupId,UserId,Accepted")] GroupRequests groupRequests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupRequests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupRequests.GroupId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", groupRequests.UserId);
            return View(groupRequests);
        }

        // GET: GroupRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupRequests = await _context.GroupRequests.FindAsync(id);
            if (groupRequests == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupRequests.GroupId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", groupRequests.UserId);
            return View(groupRequests);
        }

        // POST: GroupRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupRequestId,GroupId,UserId,Accepted")] GroupRequests groupRequests)
        {
            if (id != groupRequests.GroupRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupRequests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupRequestsExists(groupRequests.GroupRequestId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupRequests.GroupId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", groupRequests.UserId);
            return View(groupRequests);
        }

        // GET: GroupRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupRequests = await _context.GroupRequests
                .Include(g => g.Group)
                .Include(g => g.User)
                .FirstOrDefaultAsync(m => m.GroupRequestId == id);
            if (groupRequests == null)
            {
                return NotFound();
            }

            return View(groupRequests);
        }

        // POST: GroupRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupRequests = await _context.GroupRequests.FindAsync(id);
            _context.GroupRequests.Remove(groupRequests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupRequestsExists(int id)
        {
            return _context.GroupRequests.Any(e => e.GroupRequestId == id);
        }
    }
}
