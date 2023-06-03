using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManagementBusinessObjects;

namespace ProjectManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LogsController : Controller
    {
        private readonly ProjectManagementDBContext _context;

        public LogsController(ProjectManagementDBContext context)
        {
            _context = context;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            try
            {
                var projectManagementDBContext = _context.Logs.OrderByDescending(x=>x.Timestamp).Include(l => l.User);
                return View(await projectManagementDBContext.ToListAsync());
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Logs == null)
                {
                    return NotFound();
                }

                var log = await _context.Logs
                    .Include(l => l.User)
                    .FirstOrDefaultAsync(m => m.LogId == id);
                if (log == null)
                {
                    return NotFound();
                }

                return View(log);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

    }
}
