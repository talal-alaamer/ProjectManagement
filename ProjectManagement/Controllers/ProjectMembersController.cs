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
    //Authorization to make sure the user is logged in
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
        //Passing the project id as a parameter
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                //Get the user id, manager id, and project id and add them to viewbags which are used throughout the index page
                int userId = Global.userId;
                ViewBag.userId = userId;
                ViewBag.managerId = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectManagerId;
                ViewBag.projectId = id;
                //Retrieve the comments and order them alphabetically then display them in the view
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
        //Passing the project id as a paremeter
        public IActionResult Create(int id)
        {
            try
            {
                //Viewbags that store the project id and the user id to use for the create form
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
                    //Adding the project member to the database
                    _context.Add(projectMember);
                    await _context.SaveChangesAsync();

                    //Make an audit entry
                    Audit audit = new Audit();
                    audit.ChangeType = "Create";
                    audit.TableName = "ProjectMember";
                    audit.RecordId = projectMember.ProjectMemberId;
                    audit.CurrentValue = projectMember.ToString();
                    audit.UserId = Global.userId;
                    _context.Add(audit);
                    _context.SaveChanges();

                    //Creating a notification to the added user
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
                //Viewbags that store the project id and the user id to use for the create form
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
        //Passing the id as parameter
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                //Validation
                if (id == null || _context.ProjectMembers == null)
                {
                    return NotFound();
                }

                //Retrieve the project member and do some validation
                var projectMember = await _context.ProjectMembers
                    .Include(p => p.Project)
                    .Include(p => p.User)
                    .FirstOrDefaultAsync(m => m.ProjectMemberId == id);
                if (projectMember == null)
                {
                    return NotFound();
                }

                //Add the project id in a viewbag to use it in the delete form
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
        //Passing the id as parameter
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                //Validation then retrieve the project member
                if (_context.ProjectMembers == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.ProjectMembers'  is null.");
                }
                var projectMember = await _context.ProjectMembers.FindAsync(id);

                //Create an audit entry
                Audit audit = new Audit();
                audit.OldValue = projectMember.ToString();
                audit.ChangeType = "Delete";
                audit.TableName = "ProjectMember";
                audit.RecordId = projectMember.ProjectMemberId;
                audit.UserId = Global.userId;
                _context.Audits.Add(audit);
                _context.SaveChanges();

                //Delete the project member along with any tasks assigned to that member
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
