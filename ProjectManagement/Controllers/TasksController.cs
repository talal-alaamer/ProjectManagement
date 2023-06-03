using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Areas.Identity.Data;
using ProjectManagement.ViewModels;
using ProjectManagementBusinessObjects;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ProjectManagementDBContext _context;
        private readonly UserManager<Users> _userManager;

        public TasksController(ProjectManagementDBContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Tasks
        [HttpGet]
        public async Task<IActionResult> Index(int id, string taskname, string status)
        {
            try
            {
                int userId = Global.userId;
                ViewBag.userId = userId;
                ViewBag.managerId = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectManagerId;
                ViewBag.projectId = id;

                var tasks = _context.Tasks.Where(x => x.ProjectId == id).OrderBy(x => x.TaskName).Include(t => t.Project).Include(t => t.Status).Include(t => t.User).AsQueryable();
                if (!String.IsNullOrEmpty(taskname))
                {
                    tasks = tasks.Where(x => x.TaskName.Contains(taskname));
                }
                if (!String.IsNullOrEmpty(status))
                {
                    tasks = tasks.Where(x => x.StatusId == Convert.ToInt32(status));
                }

                var taskIndexVM = new TaskIndexViewModel();
                taskIndexVM.Tasks = tasks;
                taskIndexVM.Statuses = _context.TaskStatuses;

                return View(taskIndexVM);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                var task = await _context.Tasks
                    .Include(t => t.Project)
                    .Include(t => t.Status)
                    .Include(t => t.User)
                    .FirstOrDefaultAsync(m => m.TaskId == id);
                if (task == null)
                {
                    return NotFound();
                }

                return View(task);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Tasks/Create
        public IActionResult Create(int id)
        {
            try
            {
                ViewBag.ProjectId = id;
                ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectName;
                ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status");
                ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == id).Include(y => y.User), "UserId", "User.Email");
                return View();
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,Description,AssignDate,Deadline,StatusId,ProjectId,UserId")] ProjectManagementBusinessObjects.Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(task);
                    await _context.SaveChangesAsync();

                    Audit audit = new Audit();
                    audit.ChangeType = "Create";
                    audit.TableName = "Task";
                    audit.RecordId = task.TaskId;
                    audit.CurrentValue = task.ToString();
                    audit.UserId = Global.userId;
                    _context.Add(audit);
                    _context.SaveChanges();

                    var project = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault();
                    Notification notification = new Notification();
                    notification.Title = "A new task awaits";
                    notification.Message = "You have been assigned a new task for the project: " + project.ProjectName + ". Check it out by navigating to the tasks section in your project.";
                    notification.Status = "Unread";
                    notification.UserId = task.UserId;
                    _context.Add(notification);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index), new { id = task.ProjectId });
                }
                ViewBag.ProjectId = task.ProjectId;
                ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault().ProjectName;
                ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status", task.StatusId);
                ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == task.ProjectId).Include(y => y.User), "UserId", "User.Email", task.UserId);
                return View(task);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                ViewBag.ProjectId = task.ProjectId;
                ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault().ProjectName;
                ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status", task.StatusId);
                ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == task.ProjectId).Include(y => y.User), "UserId", "User.Email", task.UserId);
                return View(task);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,Description,AssignDate,Deadline,StatusId,ProjectId,UserId")] ProjectManagementBusinessObjects.Task task)
        {
            try
            {
                if (id != task.TaskId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //var oldTask = await _context.Tasks.FindAsync(id);
                        //Audit audit = new Audit();
                        //audit.ChangeType = "Edit";
                        //audit.TableName = "Tasks";
                        //audit.RecordId = task.TaskId;
                        //audit.OldValue = oldTask.ToString();
                        //audit.UserId = Global.userId;
                        //audit.CurrentValue = task.ToString();
                        //_context.Add(audit);

                        _context.Tasks.Update(task);
                        await _context.SaveChangesAsync();

                        var project = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault();
                        Notification notification = new Notification();
                        notification.Title = "Your task has some updates";
                        notification.Message = "Your task for the project: " + project.ProjectName + " has been updated by the project manager. Check it out by navigating to the tasks section in your project.";
                        notification.Status = "Unread";
                        notification.UserId = task.UserId;
                        _context.Add(notification);
                        _context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TaskExists(task.TaskId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index), new { id = task.ProjectId });
                }
                ViewBag.ProjectId = task.ProjectId;
                ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault().ProjectName;
                ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status", task.StatusId);
                ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == task.ProjectId).Include(y => y.User), "UserId", "User.Email", task.UserId);
                return View(task);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            try
            {
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                ViewBag.ProjectId = task.ProjectId;
                ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault().ProjectName;
                ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status", task.StatusId);
                ViewBag.UserId = task.UserId;
                ViewBag.Email = _context.Users.Where(x => x.UserId == task.UserId).FirstOrDefault().Email;
                return View(task);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, [Bind("TaskId,TaskName,Description,AssignDate,Deadline,StatusId,ProjectId,UserId")] ProjectManagementBusinessObjects.Task task)
        {
            try
            {
                if (id != task.TaskId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(task);
                        await _context.SaveChangesAsync();
                        var project = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault();
                        Notification notification = new Notification();
                        notification.Title = "Task status update";
                        notification.Message = "The task: "+ task.TaskName +" in the project: " + project.ProjectName + " has a status update. Check it out by navigating to the tasks section in your project.";
                        notification.Status = "Unread";
                        notification.UserId = project.ProjectManagerId;
                        _context.Add(notification);
                        _context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TaskExists(task.TaskId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index), new { id = task.ProjectId });
                }
                ViewBag.ProjectId = task.ProjectId;
                ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault().ProjectName;
                ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status", task.StatusId);
                ViewBag.UserId = task.UserId;
                ViewBag.Email = _context.Users.Where(x => x.UserId == task.UserId).FirstOrDefault().Email;
                return View(task);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                var task = await _context.Tasks
                    .Include(t => t.Project)
                    .Include(t => t.Status)
                    .Include(t => t.User)
                    .FirstOrDefaultAsync(m => m.TaskId == id);
                if (task == null)
                {
                    return NotFound();
                }

                return View(task);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Tasks == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.Tasks'  is null.");
                }
                var task = await _context.Tasks.FindAsync(id);
                Audit audit = new Audit();
                audit.OldValue = task.ToString();
                audit.ChangeType = "Delete";
                audit.TableName = "Task";
                audit.RecordId = task.TaskId;
                audit.UserId = Global.userId;
                _context.Audits.Add(audit);
                _context.SaveChanges();

                var project = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault();
                Notification notification = new Notification();
                notification.Title = "Something off your chest!";
                notification.Message = "The task: " + task.TaskName + " in the project: " + project.ProjectName + " has been deleted by the project manager.";
                notification.Status = "Unread";
                notification.UserId = project.ProjectManagerId;
                _context.Add(notification);
                _context.SaveChanges();
                if (task != null)
                {
                    var comments = _context.Comments.Where(x => x.TaskId == task.TaskId);
                    _context.Comments.RemoveRange(comments);
                    _context.Tasks.Remove(task);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = task.ProjectId });
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        private bool TaskExists(int id)
        {
          return (_context.Tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
