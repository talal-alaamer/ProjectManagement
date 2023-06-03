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
    //Authorization to make sure the user is logged in
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
        //Get the project id and search/filters as parameters
        [HttpGet]
        public async Task<IActionResult> Index(int id, string taskname, string status)
        {
            try
            {
                //Get the manager id and project id and add them to viewbags which are used throughout the index page
                int userId = Global.userId;
                ViewBag.userId = userId;
                ViewBag.managerId = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectManagerId;
                ViewBag.projectId = id;

                //Retrieve the tasks of the project and order them by alphabetical order
                var tasks = _context.Tasks.Where(x => x.ProjectId == id).OrderBy(x => x.TaskName).Include(t => t.Project).Include(t => t.Status).Include(t => t.User).AsQueryable();

                //Check if there is a search string and modify the results
                if (!String.IsNullOrEmpty(taskname))
                {
                    tasks = tasks.Where(x => x.TaskName.Contains(taskname));
                }

                //Check if there is a filter condition and modify the results
                if (!String.IsNullOrEmpty(status))
                {
                    tasks = tasks.Where(x => x.StatusId == Convert.ToInt32(status));
                }

                //Create a viewmodel object and assign it the the models required then use it as the view
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
        //Parameter to get the id
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                //Validation
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                //Retrieve the task and do some validation
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
        //Parameter to get the project id
        public IActionResult Create(int id)
        {
            try
            {
                //Viewbags that store the project id, the project name, statuses, and user id to use it for the create form
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
                    //Add the task to the database
                    _context.Add(task);
                    await _context.SaveChangesAsync();

                    //Audit the changes
                    Audit audit = new Audit();
                    audit.ChangeType = "Create";
                    audit.TableName = "Task";
                    audit.RecordId = task.TaskId;
                    audit.CurrentValue = task.ToString();
                    audit.UserId = Global.userId;
                    _context.Add(audit);
                    _context.SaveChanges();

                    //Create a new notification to the person who is assigned the task
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
                //Viewbags that store the project id, the project name, statuses, and user id to use it for the create form
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
        //Pass the id in the parameter
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                //Validation
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                //Retrieve the task and do some validation
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                //Viewbags that store the project id, the project name, statuses, and the user id to use for the edit form
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
                        //Create a new db context to fetch the old task
                        ProjectManagementDBContext dBContext = new ProjectManagementDBContext();

                        //Create a task object to store the old task values
                        var oldTask = await dBContext.Tasks.FindAsync(id);

                        //Audit the changes
                        Audit audit = new Audit();
                        audit.ChangeType = "Edit";
                        audit.TableName = "Tasks";
                        audit.RecordId = task.TaskId;
                        audit.OldValue = oldTask.ToString();
                        audit.UserId = Global.userId;
                        audit.CurrentValue = task.ToString();
                        _context.Add(audit);

                        //Update the task
                        _context.Tasks.Update(task);
                        await _context.SaveChangesAsync();

                        //Create a new notification for the user assigned the task
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
                //Viewbags that store the project id, the project name, statuses, and the user id to use for the edit form
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
        //Passing the id as a parameter
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            try
            {
                //Validation
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                //Retrieving the task and doing some validation
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                //Viewbags that store the project id, the project name, statuses, and the user id to use for the edit form
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
                //Validation
                if (id != task.TaskId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //Create a new db context to fetch the old task
                        ProjectManagementDBContext dBContext = new ProjectManagementDBContext();

                        //Creating a task object to store the old task values
                        var oldTask = await dBContext.Tasks.FindAsync(id);

                        //Audit the changes
                        Audit audit = new Audit();
                        audit.ChangeType = "Status Update";
                        audit.TableName = "Tasks";
                        audit.RecordId = task.TaskId;
                        audit.OldValue = oldTask.StatusId.ToString();
                        audit.UserId = Global.userId;
                        audit.CurrentValue = task.StatusId.ToString();
                        _context.Add(audit);

                        //Update the task in the database
                        _context.Update(task);
                        await _context.SaveChangesAsync();

                        //Create a new notification for the project manager about the status update
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
                //Viewbags that store the project id, the project name, statuses, and the user id to use for the edit form
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
        //Passing the id as parameter
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                //Validation
                if (id == null || _context.Tasks == null)
                {
                    return NotFound();
                }

                //Retrieving the task and doing some validation
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
        //Passing the id as parameter
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                //Validation then retrieving the task object
                if (_context.Tasks == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.Tasks'  is null.");
                }
                var task = await _context.Tasks.FindAsync(id);

                //Audit the changes
                Audit audit = new Audit();
                audit.OldValue = task.ToString();
                audit.ChangeType = "Delete";
                audit.TableName = "Task";
                audit.RecordId = task.TaskId;
                audit.UserId = Global.userId;
                _context.Audits.Add(audit);
                _context.SaveChanges();

                //Create a new notification to the user assigned the task
                var project = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault();
                Notification notification = new Notification();
                notification.Title = "Something off your chest!";
                notification.Message = "The task: " + task.TaskName + " in the project: " + project.ProjectName + " has been deleted by the project manager.";
                notification.Status = "Unread";
                notification.UserId = project.ProjectManagerId;
                _context.Add(notification);
                _context.SaveChanges();

                //Delete the task and all the comments on it and save it to the database
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
