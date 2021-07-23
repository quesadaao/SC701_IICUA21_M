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
    public class GroupInvitationsController : Controller
    {
        private readonly SocialGoalContext _context;

        public GroupInvitationsController(SocialGoalContext context)
        {
            _context = context;
        }

        // GET: GroupInvitations
        public async Task<IActionResult> Index()
        {
            var socialGoalContext = _context.GroupInvitations.Include(g => g.Group);
            return View(await socialGoalContext.ToListAsync());
        }

        // GET: GroupInvitations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInvitations = await _context.GroupInvitations
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupInvitationId == id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            return View(groupInvitations);
        }

        // GET: GroupInvitations/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            return View();
        }

        // POST: GroupInvitations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupInvitationId,FromUserId,GroupId,ToUserId,SentDate,Accepted")] GroupInvitations groupInvitations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupInvitations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupInvitations.GroupId);
            return View(groupInvitations);
        }

        // GET: GroupInvitations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInvitations = await _context.GroupInvitations.FindAsync(id);
            if (groupInvitations == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupInvitations.GroupId);
            return View(groupInvitations);
        }

        // POST: GroupInvitations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupInvitationId,FromUserId,GroupId,ToUserId,SentDate,Accepted")] GroupInvitations groupInvitations)
        {
            if (id != groupInvitations.GroupInvitationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupInvitations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupInvitationsExists(groupInvitations.GroupInvitationId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupInvitations.GroupId);
            return View(groupInvitations);
        }

        // GET: GroupInvitations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupInvitations = await _context.GroupInvitations
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupInvitationId == id);
            if (groupInvitations == null)
            {
                return NotFound();
            }

            return View(groupInvitations);
        }

        // POST: GroupInvitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupInvitations = await _context.GroupInvitations.FindAsync(id);
            _context.GroupInvitations.Remove(groupInvitations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupInvitationsExists(int id)
        {
            return _context.GroupInvitations.Any(e => e.GroupInvitationId == id);
        }
    }
}
