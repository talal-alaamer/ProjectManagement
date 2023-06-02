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
    public class ProjectMembersController : Controller
    {
        private readonly ProjectManagementDBContext _context;

        public ProjectMembersController(ProjectManagementDBContext context)
        {
            _context = context;
        }

        // GET: ProjectMembers
        public async Task<IActionResult> Index()
        {
            var projectManagementDBContext = _context.ProjectMembers.Include(p => p.Project).Include(p => p.User);
            return View(await projectManagementDBContext.ToListAsync());
        }

        // GET: ProjectMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectMembers == null)
            {
                return NotFound();
            }

            var projectMember = await _context.ProjectMembers
                .Include(p => p.Project)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectMemberId == id);
            if (projectMember == null)
            {
                return NotFound();
            }

            return View(projectMember);
        }

        // GET: ProjectMembers/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: ProjectMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectMemberId,UserId,ProjectId")] ProjectMember projectMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", projectMember.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", projectMember.UserId);
            return View(projectMember);
        }

        // GET: ProjectMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectMembers == null)
            {
                return NotFound();
            }

            var projectMember = await _context.ProjectMembers.FindAsync(id);
            if (projectMember == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", projectMember.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", projectMember.UserId);
            return View(projectMember);
        }

        // POST: ProjectMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectMemberId,UserId,ProjectId")] ProjectMember projectMember)
        {
            if (id != projectMember.ProjectMemberId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectMemberExists(projectMember.ProjectMemberId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", projectMember.ProjectId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", projectMember.UserId);
            return View(projectMember);
        }

        // GET: ProjectMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectMembers == null)
            {
                return NotFound();
            }

            var projectMember = await _context.ProjectMembers
                .Include(p => p.Project)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectMemberId == id);
            if (projectMember == null)
            {
                return NotFound();
            }

            return View(projectMember);
        }

        // POST: ProjectMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectMembers == null)
            {
                return Problem("Entity set 'ProjectManagementDBContext.ProjectMembers'  is null.");
            }
            var projectMember = await _context.ProjectMembers.FindAsync(id);
            if (projectMember != null)
            {
                _context.ProjectMembers.Remove(projectMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectMemberExists(int id)
        {
          return (_context.ProjectMembers?.Any(e => e.ProjectMemberId == id)).GetValueOrDefault();
        }
    }
}
