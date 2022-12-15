using Microsoft.AspNetCore.Mvc;

namespace AdaniCall.Controllers
{
    public class LandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
