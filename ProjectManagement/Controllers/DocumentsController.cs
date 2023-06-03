using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementBusinessObjects;

namespace ProjectManagement.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        private readonly ProjectManagementDBContext _context;

        public DocumentsController(ProjectManagementDBContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index(int id)
        {
            try
            {
                int userId = Global.userId;
                ViewBag.userId = userId;
                ViewBag.taskId = id;
                ViewBag.projectId = _context.Tasks.Where(x => x.TaskId == id).FirstOrDefault().ProjectId;
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
        public IActionResult Create(int id)
        {
            try
            {
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentId,DocumentName,UploadTime,Path,TypeId,UserId,TaskId")] Document document, IFormFile file)
        {
            try
            {
                String path;
                if(file.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UploadedFiles", file.FileName);
                    var dbfilePath = Path.Combine("UploadedFiles", file.FileName);
                    path = filePath;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    document.Path = dbfilePath.ToString();
                }

                _context.Add(document);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

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
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null || _context.Documents == null)
                {
                    return NotFound();
                }

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
                if (_context.Documents == null)
                {
                    return Problem("Entity set 'ProjectManagementDBContext.Documents'  is null.");
                }
                var document = await _context.Documents.FindAsync(id);
                if (document != null)
                {
                    _context.Documents.Remove(document);
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

        private bool DocumentExists(int id)
        {
          return (_context.Documents?.Any(e => e.DocumentId == id)).GetValueOrDefault();
        }
    }
}
