using System;
using System.Collections.Generic;
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
    public class AuditsController : Controller
    {
        private readonly ProjectManagementDBContext _context;

        public AuditsController(ProjectManagementDBContext context)
        {
            _context = context;
        }

        // GET: Audits
        public async Task<IActionResult> Index()
        {
            try
            {
                var projectManagementDBContext = _context.Audits.OrderByDescending(x=>x.Timestamp).Include(a => a.User);
                return View(await projectManagementDBContext.ToListAsync());
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Audits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Audits == null)
                {
                    return NotFound();
                }

                var audit = await _context.Audits
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(m => m.AuditId == id);
                if (audit == null)
                {
                    return NotFound();
                }

                return View(audit);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

    }
}
