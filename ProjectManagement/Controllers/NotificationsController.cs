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
    //Authorization to make sure the user is logged in
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly ProjectManagementDBContext _context;

        public NotificationsController(ProjectManagementDBContext context)
        {
            _context = context;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            try
            {
                //Retrieve the notifications and order them from latest to oldest then display them in the view
                int userId = Global.userId;
                var projectManagementDBContext = _context.Notifications.Where(x => x.UserId == userId).OrderByDescending(x => x.NotificationId).Include(n => n.User);
                return View(await projectManagementDBContext.ToListAsync());
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        // GET: Notifications/Details/5
        //Passing the task id as parameter
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                //Validation
                if (id == null || _context.Notifications == null)
                {
                    return NotFound();
                }

                //Retrieve the notification object and do some validation
                var notification = await _context.Notifications
                    .Include(n => n.User)
                    .FirstOrDefaultAsync(m => m.NotificationId == id);
                if (notification == null)
                {
                    return NotFound();
                }

                //Update the notification status to read once opened and save the changes
                if (notification.Status == "Unread")
                {
                    notification.Status = "Read";
                    _context.Update(notification);
                    _context.SaveChanges();
                }

                return View(notification);
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }
    }
}
