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
        public async Task<IActionResult> Index(int id)
        {
            int userId = GetIdAsync().Result;
            ViewBag.userId = userId;
            ViewBag.managerId = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectManagerId;
            ViewBag.projectId = id;
            var projectManagementDBContext = _context.Tasks.Where(x=>x.ProjectId==id).Include(t => t.Project).Include(t => t.Status).Include(t => t.User);
            return View(await projectManagementDBContext.ToListAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Tasks/Create
        public IActionResult Create(int id)
        {
            ViewBag.ProjectId = id;
            ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == id).FirstOrDefault().ProjectName;
            ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status");
            ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == id).Include(y=>y.User), "UserId", "User.Email");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,Description,AssignDate,Deadline,StatusId,ProjectId,UserId")] ProjectManagementBusinessObjects.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = task.ProjectId });
            }
            ViewBag.ProjectId = task.ProjectId;
            ViewBag.ProjectName = _context.Projects.Where(x => x.ProjectId == task.ProjectId).FirstOrDefault().ProjectName;
            ViewData["StatusId"] = new SelectList(_context.TaskStatuses, "TaskStatusId", "Status", task.StatusId);
            ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x=>x.ProjectId==task.ProjectId).Include(y => y.User), "UserId", "User.Email", task.UserId);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x=>x.ProjectId==task.ProjectId).Include(y => y.User), "UserId", "User.Email", task.UserId);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,Description,AssignDate,Deadline,StatusId,ProjectId,UserId")] ProjectManagementBusinessObjects.Task task)
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

        // GET: Tasks/Edit/5
        public async Task<IActionResult> UpdateStatus(int? id)
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

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, [Bind("TaskId,TaskName,Description,AssignDate,Deadline,StatusId,ProjectId,UserId")] ProjectManagementBusinessObjects.Task task)
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

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'ProjectManagementDBContext.Tasks'  is null.");
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = task.ProjectId });
        }

        private bool TaskExists(int id)
        {
          return (_context.Tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
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
