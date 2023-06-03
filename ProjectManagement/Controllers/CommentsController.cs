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
        //Passing the task id as parameter
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                //Get the user id, task id, and project id and add them to viewbags which are used throughout the index page
                int userId = Global.userId;
                ViewBag.userId = userId;
                ViewBag.taskId = id;
                ViewBag.projectId = _context.Tasks.Where(x => x.TaskId == id).FirstOrDefault().ProjectId;
                //Retrieve the comments and order them from latest to oldest then display them in the view
                var projectManagementDBContext = _context.Comments.Where(x => x.TaskId == id).OrderByDescending(x => x.CommentTimestamp).Include(c => c.Task).Include(c => c.User);
                return View(await projectManagementDBContext.ToListAsync());
            }catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Comments/Create
        //Passing the task id as parameter
        public IActionResult Create(int id)
        {
            try {
                //Viewbags that store the task id and the user id/username to use for the create form
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
                    //Add the comment to the database
                    _context.Add(comment);
                    await _context.SaveChangesAsync();

                    //Audit the changes
                    Audit audit = new Audit();
                    audit.ChangeType = "Create";
                    audit.TableName = "Comments";
                    audit.RecordId = comment.CommentId;
                    audit.CurrentValue = comment.ToString();
                    audit.UserId = Global.userId;
                    _context.Add(audit);
                    _context.SaveChanges();

                    //Create a notification for the user responsible of the task
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
                //Viewbags that store the task id and the user id/username to use for the create form
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
        //Passing the task id as parameter
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                //Validation
                if (id == null || _context.Comments == null)
                {
                    return NotFound();
                }

                //Retrieve the comment and do some validation
                var comment = await _context.Comments.FindAsync(id);
                if (comment == null)
                {
                    return NotFound();
                }
                //Viewbags that store the task id and the user id/username to use for the edit form
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
                //Validation
                if (id != comment.CommentId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //Create a new db context to fetch the old comment
                        ProjectManagementDBContext dBContext = new ProjectManagementDBContext();

                        //Creating an old comment object to get the comment values before updating
                        var oldComment = await dBContext.Comments.FindAsync(id);

                        //Audit the changes
                        Audit audit = new Audit();
                        audit.ChangeType = "Edit";
                        audit.TableName = "Comments";
                        audit.RecordId = comment.CommentId;
                        audit.OldValue = oldComment.ToString();
                        audit.UserId = Global.userId;
                        audit.CurrentValue = comment.ToString();
                        _context.Add(audit);

                        //Save the comment
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
                //Viewbags that store the task id and the user id/username to use for the edit form
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
        //Passing the task id as parameter
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                //Store the task id in a viewbag to use in the delete form
                ViewBag.TaskId = _context.Comments.Where(x => x.CommentId == id).FirstOrDefault().TaskId;

                //Validation
                if (id == null || _context.Comments == null)
                {
                    return NotFound();
                }

                //Retrieve the comment and do some validation
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
                //Get the task id of the comment
                int taskId = Convert.ToInt32(_context.Comments.Where(x => x.CommentId == id).FirstOrDefault().TaskId);
                //Validation then retrieving the comment
                if (_context.Comments == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.Comments'  is null.");
                }
                var comment = await _context.Comments.FindAsync(id);

                //Auditing the changes
                Audit audit = new Audit();
                audit.OldValue = comment.ToString();
                audit.ChangeType = "Delete";
                audit.TableName = "Comments";
                audit.RecordId = comment.CommentId;
                audit.UserId = Global.userId;
                _context.Audits.Add(audit);
                _context.SaveChanges();

                //Removing the comment from the database and saving
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
