using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ElectricBillController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
