using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static string adminId = "admin@gmail.com";
        static string adminPass = "123";

        static string customerId = "cust@gmail.com";
        static string customerPass = "1234";

        static IList<user> userList = new List<user>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult loginPage()
        {
            return View();
        }

        public IActionResult login()
        {
            return View("loginPage");
        }
        public IActionResult AddUser(user userDetails)
        {
            userList.Add(userDetails);
            return RedirectToAction("login");
        }
        public IActionResult checkCredentials(login inputDetails)
        {
            Console.WriteLine("Input : ", inputDetails);
            if (inputDetails.loginId == adminId && inputDetails.password == adminPass)
            {
                return RedirectToAction("adminIndex", "Admin");
            }
            else if (inputDetails.loginId == customerId && inputDetails.password == customerPass)
            {
                return RedirectToAction("customerIndex", "Customer");
            }
            foreach (var eachUser in userList)
            {
                if(eachUser.email == inputDetails.loginId && inputDetails.password == eachUser.password)
                {
                    return RedirectToAction("customerIndex", "Customer", inputDetails);
                }
                
            }
            ViewBag.errorMessage = "Invalid LoginId or password. Try again...";
            return View("loginPage");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}