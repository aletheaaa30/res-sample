using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult CreateUser()
        {
            return View();
        }
    }
}
