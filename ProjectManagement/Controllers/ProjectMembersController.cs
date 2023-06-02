using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Areas.Identity.Data;
using ProjectManagementBusinessObjects;

namespace ProjectManagement.Controllers
{
    public class ProjectMembersController : Controller
    {
        private readonly ProjectManagementDBContext _context;
        private readonly UserManager<Users> _userManager;

        public ProjectMembersController(ProjectManagementDBContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ProjectMembers
        public async Task<IActionResult> Index(int id)
        {
            int userId = GetIdAsync().Result;
            ViewBag.userId = userId;
            ViewBag.managerId = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectManagerId;
            ViewBag.projectId = id;
            var projectManagementDBContext = _context.ProjectMembers.Where(x => x.ProjectId == id).Include(p => p.Project).Include(p => p.User);
            return View(await projectManagementDBContext.ToListAsync());
        }


        // GET: ProjectMembers/Create
        public IActionResult Create(int id)
        {
            ViewData["ProjectId"] = id;
            ViewData["UserId"] = new SelectList(_context.Users.Where(x=>!x.ProjectMembers.Any(y=>y.ProjectId==id)), "UserId", "Email");
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
                return RedirectToAction(nameof(Index), new { id = projectMember.ProjectId });
            }
            ViewData["ProjectId"] = projectMember.ProjectId;
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => !x.ProjectMembers.Any(y => y.ProjectId == projectMember.ProjectId)), "UserId", "Email");
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
            ViewBag.projectId = projectMember.ProjectId;
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
                var tasks = _context.Tasks.Where(x => x.ProjectId == projectMember.ProjectId && x.UserId==projectMember.UserId);
                _context.Tasks.RemoveRange(tasks);
                _context.ProjectMembers.Remove(projectMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = projectMember.ProjectId });
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
