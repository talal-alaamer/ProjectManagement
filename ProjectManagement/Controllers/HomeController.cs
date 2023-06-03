using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Areas.Identity.Data;
using ProjectManagement.Data;
using ProjectManagementBusinessObjects;
using System.Diagnostics;

namespace ProjectManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IdentityContext _context;
        private readonly ProjectManagementDBContext _dbContext;
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(UserManager<Users> userManager, SignInManager<Users> signInManager, IdentityContext context, ProjectManagementDBContext dbcontext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _dbContext = dbcontext;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        
        public async Task<IActionResult> IndexAsync()
        {
        try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var currentUser = await _userManager.GetUserAsync(User);
                    String email = currentUser.Email;
                    Global.userId = Convert.ToInt32(_dbContext.Users.Where(x => x.Email == email).FirstOrDefault().UserId);
                }

                int totalUsers = _context.Users.Count();
                ViewData["TotalUsers"] = totalUsers;
                int totalUsers = _context.Users.Count();
            ViewData["TotalUsers"] = totalUsers;

            // Get the total number of projects
            int? totalProjects = CountProjects();

            // If totalProjects is null, assign a default value of 0
            int displayValue = totalProjects ?? 0;

            // Store the total number of projects in a ViewBag property
            ViewBag.TotalProjects = displayValue;

            // Get the total number of tasks
            int? totalTasks = CountTasks();

            // If totalTasks is null, assign a default value of 0
            int displayValue2 = totalTasks ?? 0;

            // Store the total number of tasks in a ViewBag property
            ViewBag.TotalTasks = displayValue2;

            // Get the total number of active tasks
            int? totalActive = CountActiveTasks();

            // If totalActive is null, assign a default value of 0
            int displayValue3 = totalActive ?? 0;

            // Store the total number of active tasks in a ViewBag property
            ViewBag.TotalActive = displayValue3;
                return View();
            }catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }

        public int? CountProjects()
        {
            int count = context1.Projects.Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountTasks()
        {
            int count = context1.Tasks.Count();
            return count == 0 ? null : (int?)count;
        }

        public int? CountActiveTasks()
        {
            int count = context1.Tasks.Where(x=> x.StatusId == 2).Count();
            return count == 0 ? null : (int?)count;
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            try
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
        }
    }
}