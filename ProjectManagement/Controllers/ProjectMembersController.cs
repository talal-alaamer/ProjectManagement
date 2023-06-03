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
            try
            {
                int userId = Global.userId;
                ViewBag.userId = userId;
                ViewBag.managerId = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectManagerId;
                ViewBag.projectId = id;
                var projectManagementDBContext = _context.ProjectMembers.Where(x => x.ProjectId == id).OrderBy(x => x.User.Email).Include(p => p.Project).Include(p => p.User);
                return View(await projectManagementDBContext.ToListAsync());
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }


        // GET: ProjectMembers/Create
        public IActionResult Create(int id)
        {
            try
            {
                ViewData["ProjectId"] = id;
                ViewData["UserId"] = new SelectList(_context.Users.Where(x => !x.ProjectMembers.Any(y => y.ProjectId == id)), "UserId", "Email");
                return View();
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: ProjectMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectMemberId,UserId,ProjectId")] ProjectMember projectMember)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(projectMember);
                    await _context.SaveChangesAsync();

                    Audit audit = new Audit();
                    audit.ChangeType = "Create";
                    audit.TableName = "ProjectMember";
                    audit.RecordId = projectMember.ProjectMemberId;
                    audit.CurrentValue = projectMember.ToString();
                    audit.UserId = Global.userId;
                    _context.Add(audit);
                    _context.SaveChanges();

                    var project = _context.Projects.Where(x => x.ProjectId == projectMember.ProjectId).FirstOrDefault();
                    Notification notification = new Notification();
                    notification.Title = "Welcome to the team!";
                    notification.Message = "You have been added to the project: " + project.ProjectName + ". Check it out by navigating to your projects.";
                    notification.Status = "Unread";
                    notification.UserId = projectMember.UserId;
                    _context.Add(notification);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index), new { id = projectMember.ProjectId });
                }
                ViewData["ProjectId"] = projectMember.ProjectId;
                ViewData["UserId"] = new SelectList(_context.Users.Where(x => !x.ProjectMembers.Any(y => y.ProjectId == projectMember.ProjectId)), "UserId", "Email");
                return View(projectMember);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: ProjectMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: ProjectMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.ProjectMembers == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.ProjectMembers'  is null.");
                }

                var projectMember = await _context.ProjectMembers.FindAsync(id);
                Audit audit = new Audit();
                audit.OldValue = projectMember.ToString();
                audit.ChangeType = "Delete";
                audit.TableName = "ProjectMember";
                audit.RecordId = projectMember.ProjectMemberId;
                audit.UserId = Global.userId;
                _context.Audits.Add(audit);
                _context.SaveChanges();

                if (projectMember != null)
                {
                    var tasks = _context.Tasks.Where(x => x.ProjectId == projectMember.ProjectId && x.UserId == projectMember.UserId);
                    _context.Tasks.RemoveRange(tasks);
                    _context.ProjectMembers.Remove(projectMember);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = projectMember.ProjectId });
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }
    }
}
