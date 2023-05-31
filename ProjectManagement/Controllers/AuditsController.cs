using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementBusinessObjects;

namespace ProjectManagement.Controllers
{
    public class AuditsController : Controller
    {
        private readonly ProjectManagementDBContext _context;

        public AuditsController(ProjectManagementDBContext context)
        {
            _context = context;
        }

        // GET: Audits
        public async Task<IActionResult> Index()
        {
            var projectManagementDBContext = _context.Audits.Include(a => a.User);
            return View(await projectManagementDBContext.ToListAsync());
        }

        // GET: Audits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Audits == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AuditId == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // GET: Audits/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: Audits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditId,Timestamp,ChangeType,TableName,RecordId,OldValue,CurrentValue,UserId")] Audit audit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(audit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", audit.UserId);
            return View(audit);
        }

        // GET: Audits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Audits == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits.FindAsync(id);
            if (audit == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", audit.UserId);
            return View(audit);
        }

        // POST: Audits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuditId,Timestamp,ChangeType,TableName,RecordId,OldValue,CurrentValue,UserId")] Audit audit)
        {
            if (id != audit.AuditId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(audit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditExists(audit.AuditId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", audit.UserId);
            return View(audit);
        }

        // GET: Audits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Audits == null)
            {
                return NotFound();
            }

            var audit = await _context.Audits
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.AuditId == id);
            if (audit == null)
            {
                return NotFound();
            }

            return View(audit);
        }

        // POST: Audits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Audits == null)
            {
                return Problem("Entity set 'ProjectManagementDBContext.Audits'  is null.");
            }
            var audit = await _context.Audits.FindAsync(id);
            if (audit != null)
            {
                _context.Audits.Remove(audit);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditExists(int id)
        {
          return (_context.Audits?.Any(e => e.AuditId == id)).GetValueOrDefault();
        }
    }
}
