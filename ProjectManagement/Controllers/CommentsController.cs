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
    public class CommentsController : Controller
    {
        private readonly ProjectManagementDBContext _context;
        private readonly UserManager<Users> _userManager;

        public CommentsController(ProjectManagementDBContext context, UserManager<Users> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Comments
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                int userId = Global.userId;
                ViewBag.userId = userId;
                ViewBag.taskId = id;
                ViewBag.projectId = _context.Tasks.Where(x => x.TaskId == id).FirstOrDefault().ProjectId;
                var projectManagementDBContext = _context.Comments.Where(x => x.TaskId == id).OrderByDescending(x => x.CommentTimestamp).Include(c => c.Task).Include(c => c.User);
                return View(await projectManagementDBContext.ToListAsync());
            }catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Comments/Create
        public IActionResult Create(int id)
        {
            try {
            ViewData["TaskId"] = id;
            int userId = Global.userId;
            ViewBag.CommenterId = userId;
            ViewBag.Commenter = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
            return View();
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,CommentTimestamp,CommentText,UserId,TaskId")] Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(comment);
                    await _context.SaveChangesAsync();

                    Audit audit = new Audit();
                    audit.ChangeType = "Create";
                    audit.TableName = "Comments";
                    audit.RecordId = comment.CommentId;
                    audit.CurrentValue = comment.ToString();
                    audit.UserId = Global.userId;
                    _context.Add(audit);
                    _context.SaveChanges();

                    var task = _context.Tasks.Where(x=>x.TaskId == comment.TaskId).FirstOrDefault();
                    Notification notification = new Notification();
                    notification.Title = "You have a new comment";
                    notification.Message = "Someone has added a new comment to your task: "+task.TaskName+". Check it out by navigating to the task's comment section.";
                    notification.Status = "Unread";
                    notification.UserId = task.UserId;
                    _context.Add(notification);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index), new { id = comment.TaskId });
                }
                ViewData["TaskId"] = comment.TaskId;
                int userId = Global.userId;
                ViewBag.CommenterId = userId;
                ViewBag.Commenter = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                return View(comment);
            }catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null || _context.Comments == null)
                {
                    return NotFound();
                }

                var comment = await _context.Comments.FindAsync(id);
                if (comment == null)
                {
                    return NotFound();
                }
                ViewData["TaskId"] = comment.TaskId;
                int userId = Global.userId;
                ViewBag.CommenterId = userId;
                ViewBag.Commenter = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                ViewBag.Timestamp = _context.Comments.Where(x => x.CommentId == id).FirstOrDefault().CommentTimestamp;
                return View(comment);
            }catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,CommentTimestamp,CommentText,UserId,TaskId")] Comment comment)
        {
            try
            {
                if (id != comment.CommentId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //var oldComment = await _context.Comments.FindAsync(id);
                        //Audit audit = new Audit();
                        //audit.ChangeType = "Edit";
                        //audit.TableName = "Comments";
                        //audit.RecordId = comment.CommentId;
                        //audit.OldValue = oldComment.ToString();
                        //audit.UserId = Global.userId;
                        //audit.CurrentValue = comment.ToString();
                        //_context.Add(audit);

                        _context.Update(comment);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CommentExists(comment.CommentId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index), new { id = comment.TaskId });
                }
                ViewData["TaskId"] = comment.TaskId;
                int userId = Global.userId;
                ViewBag.CommenterId = userId;
                ViewBag.Commenter = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                return View(comment);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                ViewBag.TaskId = _context.Comments.Where(x => x.CommentId == id).FirstOrDefault().TaskId;
                if (id == null || _context.Comments == null)
                {
                    return NotFound();
                }

                var comment = await _context.Comments
                    .Include(c => c.Task)
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(m => m.CommentId == id);
                if (comment == null)
                {
                    return NotFound();
                }

                return View(comment);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                int taskId = Convert.ToInt32(_context.Comments.Where(x => x.CommentId == id).FirstOrDefault().TaskId);
                if (_context.Comments == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.Comments'  is null.");
                }
                var comment = await _context.Comments.FindAsync(id);
                Audit audit = new Audit();
                audit.OldValue = comment.ToString();
                audit.ChangeType = "Delete";
                audit.TableName = "Comments";
                audit.RecordId = comment.CommentId;
                audit.UserId = Global.userId;
                _context.Audits.Add(audit);
                _context.SaveChanges();

                if (comment != null)
                {
                    _context.Comments.Remove(comment);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = taskId });
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        private bool CommentExists(int id)
        {
          return (_context.Comments?.Any(e => e.CommentId == id)).GetValueOrDefault();
        }
    }
}
