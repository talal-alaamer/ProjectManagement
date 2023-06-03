﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
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
        public async Task<IActionResult> Index(string projectname, string manager)
        {
            try
            {
                int userId = Global.userId;
                ViewBag.userId = userId;
                var projects = _context.Projects.Where(x => _context.ProjectMembers.Any(y => y.UserId == userId && y.ProjectId == x.ProjectId)).OrderBy(x => x.ProjectName).Include(p => p.ProjectManager).AsQueryable();
                if (!String.IsNullOrEmpty(projectname))
                {
                    projects = projects.Where(x => x.ProjectName.Contains(projectname));
                }
                if (!String.IsNullOrEmpty(manager))
                {
                    if (manager == "1")
                    {
                        projects = projects.Where(x => x.ProjectManagerId == userId);
                    }
                    else if (manager == "2")
                    {
                        projects = projects.Where(x => x.ProjectManagerId != userId);

                    }
                }
                return View(projects);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Projects/Create
        public async Task<IActionResult> CreateAsync()
        {
            try
            {
                int userId = Global.userId;
                ViewBag.ProjectManagerId = userId;
                ViewBag.ProjectManager = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                return View();
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,ProjectName,Description,ProjectManagerId")] ProjectManagementBusinessObjects.Project project)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProjectMember pm = new ProjectMember();
                    _context.Add(project);
                    await _context.SaveChangesAsync();

                    Audit audit = new Audit();
                    audit.ChangeType = "Create";
                    audit.TableName = "Project";
                    audit.RecordId = project.ProjectId;
                    audit.CurrentValue = project.ToString();
                    audit.UserId = Global.userId;
                    _context.Add(audit);
                    _context.SaveChanges();

                    pm.ProjectId = project.ProjectId;
                    pm.UserId = project.ProjectManagerId;
                    _context.ProjectMembers.Add(pm);
                    await _context.SaveChangesAsync();

                    Notification notification = new Notification();
                    notification.Title = "We have got a leader!";
                    notification.Message = "You have successfully created a new project with the name:" + project.ProjectName + ". You may add members and create new tasks by going to the projects tab.";
                    notification.Status = "Unread";
                    notification.UserId = project.ProjectManagerId;
                    _context.Add(notification);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                int userId = Global.userId;
                ViewBag.ProjectManagerId = userId;
                ViewBag.ProjectManager = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                return View(project);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
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
                int userId = Global.userId;
                ViewBag.ProjectManagerId = userId;
                ViewBag.ProjectManager = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                return View(project);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,ProjectName,Description,ProjectManagerId")] ProjectManagementBusinessObjects.Project project)
        {
            try
            {
                if (id != project.ProjectId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //var oldProject = await _context.Projects.FindAsync(id);
                        Audit audit = new Audit();
                        audit.ChangeType = "Edit";
                        audit.TableName = "Project";
                        audit.RecordId = project.ProjectId;
                        //audit.OldValue = oldProject.ToString();
                        audit.UserId = Global.userId;
                        audit.CurrentValue = project.ToString();
                        _context.Add(audit);

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
                int userId = Global.userId;
                ViewBag.ProjectManager = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                ViewBag.ProjectManagerId = userId;
                return View(project);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                if (_context.Projects == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.Projects'  is null.");
                }
                var project = await _context.Projects.FindAsync(id);
                Audit audit = new Audit();
                audit.OldValue = project.ToString();
                audit.ChangeType = "Delete";
                audit.TableName = "Project";
                audit.RecordId = project.ProjectId;
                audit.UserId = Global.userId;
                _context.Audits.Add(audit);
                _context.SaveChanges();

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
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        public int? CountTasks(int id)
        {
            int count = _context.Tasks.Where(x=> x.ProjectId == id).Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountOverdue(int id)
        {
            int count = _context.Tasks.Where(x => x.ProjectId == id && x.Deadline < DateTime.Now).Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountCompleted(int id)
        {
            int count = _context.Tasks.Where(x => x.ProjectId == id && x.StatusId == 3).Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountComment(int id)
        {
            int count = _context.Projects.Where(p => p.ProjectId == id).SelectMany(p => p.Tasks).SelectMany(t => t.Comments).Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountMembers(int id)
        {
            int count = _context.ProjectMembers.Where(p => p.ProjectId == id).Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountDocuments(int id)
        {
            int count = _context.Projects.Where(p => p.ProjectId == id).SelectMany(p => p.Tasks).SelectMany(t => t.Documents).Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountActiveTasks()
        {
            int count = _context.Tasks.Where(x => x.StatusId == 2).Count();
            return count == 0 ? null : (int?)count;
        }

        public async Task<IActionResult> Dashboard(int id)
        {
            try
            {
                var projectManagementDBContext = _context.Projects.Where(x => x.ProjectId == id).Include(p => p.ProjectManager);
                
                int? totalTasks = CountTasks(id);

                // If totalTasks is null, assign a default value of 0
                int displayValue = totalTasks ?? 0;

                // Store the total number of tasks in a ViewBag property
                ViewBag.TotalTasks = displayValue;

                int? totalComplete = CountCompleted(id);

                // If totalTasks is null, assign a default value of 0
                int displayValue2 = totalComplete ?? 0;

                // Store the total number of tasks in a ViewBag property
                ViewBag.TotalComplete = displayValue2;

                int? totalOverdue = CountOverdue(id);

                // If totalTasks is null, assign a default value of 0
                int displayValue3 = totalOverdue ?? 0;

                // Store the total number of tasks in a ViewBag property
                ViewBag.TotalOverdue = displayValue3;

                int? totalComment = CountComment(id);

                // If totalTasks is null, assign a default value of 0
                int displayValue4 = totalComment ?? 0;

                // Store the total number of tasks in a ViewBag property
                ViewBag.TotalComment = displayValue4;


                int? totalMembers = CountMembers(id);

                // If totalTasks is null, assign a default value of 0
                int displayValue5 = totalMembers ?? 0;

                // Store the total number of tasks in a ViewBag property
                ViewBag.TotalMembers = displayValue5;


                int? totalDocuments = CountDocuments(id);

                // If totalTasks is null, assign a default value of 0
                int displayValue6 = totalDocuments ?? 0;

                // Store the total number of tasks in a ViewBag property
                ViewBag.TotalDocuments = displayValue6;

                // Get the total number of active tasks
                int? totalActive = CountActiveTasks();

                // If totalActive is null, assign a default value of 0
                int displayValue7 = totalActive ?? 0;

                // Store the total number of active tasks in a ViewBag property
                ViewBag.TotalActive = displayValue7;

                return View();
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        private bool ProjectExists(int id)
        {
          return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
