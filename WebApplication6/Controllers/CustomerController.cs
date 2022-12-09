using Microsoft.AspNetCore.Mvc;

namespace WebApplication6.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult customerIndex()
        {
            return View();
        }
    }
}
