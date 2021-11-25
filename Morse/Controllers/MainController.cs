using Microsoft.AspNetCore.Mvc;

namespace Morse.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
