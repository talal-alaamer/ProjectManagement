using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Areas.Identity.Data;
using ProjectManagementBusinessObjects;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private readonly ProjectManagementDBContext _context;
        private readonly UserManager<Users> _userManager;

        public ProjectsController(ProjectManagementDBContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            int userId = GetIdAsync().Result;
            ViewBag.userId = userId;
            var projectManagementDBContext = _context.Projects.Where(x => _context.ProjectMembers.Any(y=> y.UserId == userId && y.ProjectId==x.ProjectId) || x.ProjectManagerId==userId).Include(p => p.ProjectManager);
            return View(await projectManagementDBContext.ToListAsync());
        }

        // GET: Projects/Create
        public async Task<IActionResult> CreateAsync()
        {
            int userId = GetIdAsync().Result;
            ViewBag.ProjectManagerId = userId;
            ViewBag.ProjectManager = _context.Users.Where(x=>x.UserId == userId).FirstOrDefault().Email;
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,Description,ProjectManagerId")] Project project)
        {
            if (ModelState.IsValid)
            {
                ProjectMember pm = new ProjectMember();
                _context.Add(project);
                await _context.SaveChangesAsync();
                pm.ProjectId = project.ProjectId;
                pm.UserId = project.ProjectManagerId;
                _context.ProjectMembers.Add(pm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            int userId = GetIdAsync().Result;
            ViewBag.ProjectManagerId = userId;
            ViewBag.ProjectManager = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            int userId = GetIdAsync().Result;
            ViewBag.ProjectManagerId = userId;
            ViewBag.ProjectManager = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,Description,ProjectManagerId")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            int userId = GetIdAsync().Result;
            ViewBag.ProjectManager = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
            ViewBag.ProjectManagerId = userId;
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.ProjectManager)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'ProjectManagementDBContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                var tasks = _context.Tasks.Where(x => x.ProjectId == project.ProjectId);
                _context.Tasks.RemoveRange(tasks);
                var members = _context.ProjectMembers.Where(x => x.ProjectId == project.ProjectId);
                _context.ProjectMembers.RemoveRange(members);
                _context.Projects.Remove(project);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
          return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }

        private async Task<int> GetIdAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            String email = currentUser.Email;
            int userId = Convert.ToInt32(_context.Users.Where(x => x.Email == email).FirstOrDefault().UserId);
            return userId;
        }
    }
}
