using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ProjectManagementBusinessObjects;

namespace ProjectManagement.Controllers
{
    //Authorization to make sure the user is logged in
    [Authorize]
    public class DocumentsController : Controller
    {
        private readonly ProjectManagementDBContext _context;

        public DocumentsController(ProjectManagementDBContext context)
        {
            _context = context;
        }

        // GET: Documents
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
                //Retrieve the documents and order them from latest to oldest then display them in the view
                var projectManagementDBContext = _context.Documents.Where(x => x.TaskId == id).OrderByDescending(x => x.UploadTime).Include(d => d.Task).Include(d => d.Type).Include(d => d.User);
                return View(await projectManagementDBContext.ToListAsync());
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Documents/Create
        //Passing the task id as parameter
        public IActionResult Create(int id)
        {
            try
            {
                //Viewbags that store the task id, the document types, and the user id/username to use for the create form
                ViewBag.taskId = id;
                ViewData["TypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Type");
                ViewData["UserId"] = Global.userId;
                int userId = Global.userId;
                ViewBag.Username = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                return View();
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Accept files as a parameter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,DocumentName,UploadTime,Path,TypeId,UserId,TaskId")] Document document, List<IFormFile> files)
        {
            try
            {
                //Get the file size and make a var to store the file names
                long size = files.Sum(f => f.Length);
                var filePaths = new List<string>();
                
                //Loop through the uploaded files
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        // The full path to file in temp location
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles", formFile.FileName);

                        //The path for the database then adding it to the list of paths
                        var dbfilePath = Path.Combine("UploadedFiles", formFile.FileName);
                        filePaths.Add(filePath);
                        
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            //Copy the contents of the uploaded file to the filestream
                            await formFile.CopyToAsync(stream);
                        }

                        //Assigning the document path property
                        document.Path = dbfilePath.ToString();
                    }
                }

                //Adding the document to the database
                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = document.TaskId });
                //Viewbags that store the task id, the document types, and the user id/username to use for the create form
                ViewBag.taskId = document.TaskId;
                ViewData["TypeId"] = new SelectList(_context.DocumentTypes, "DocumentTypeId", "Type");
                ViewData["UserId"] = Global.userId;
                int userId = Global.userId;
                ViewBag.Username = _context.Users.Where(x => x.UserId == userId).FirstOrDefault().Email;
                return View(document);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Documents/Delete/5
        //Passing the task id as parameter
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                ViewBag.TaskId = _context.Documents.Where(x => x.DocumentId == id).FirstOrDefault().TaskId;
                //Validation
                if (id == null || _context.Documents == null)
                {
                    return NotFound();
                }

                //Retrieve the document and check if it exists
                var document = await _context.Documents
                    .Include(d => d.Task)
                    .Include(d => d.Type)
                    .Include(d => d.User)
                    .FirstOrDefaultAsync(m => m.DocumentId == id);
                if (document == null)
                {
                    return NotFound();
                }

                return View(document);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                //Validation
                if (_context.Documents == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.Documents'  is null.");
                }

                //Retrieving the document object, doing validation, then deleting it
                var document = await _context.Documents.FindAsync(id);
                if (document != null)
                {
                    _context.Documents.Remove(document);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = document.TaskId });
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        private bool DocumentExists(int id)
        {
            return (_context.Documents?.Any(e => e.DocumentId == id)).GetValueOrDefault();
        }
    }
}
