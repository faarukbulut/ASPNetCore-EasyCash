using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class MyLastProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
