using EntityFrameworkCoreGuideNET8.Business.UI.Models;
using EntityFrameworkCoreGuideNET8.Infrastructure.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EntityFrameworkCoreGuideNET8.Business.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActiveUser()
        {
            try
            {
                var user = await _userService.GetAllActiveUsersAsync();
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the user.");
                return StatusCode(500, "An unexpected error occurred.");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
