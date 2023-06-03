using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                return View();
            }
            catch (Exception ex)
            {
                Global.LogException(ex, Global.userId);
                return View();
            }
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