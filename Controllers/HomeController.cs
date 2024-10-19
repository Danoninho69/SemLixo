using Microsoft.AspNetCore.Mvc;

namespace LixoMelhor.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
