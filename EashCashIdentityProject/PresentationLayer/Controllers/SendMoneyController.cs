using DataAccessLayer.Concrete;
using DtoLayer.Dtos.CustomerAccountProcessDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SendMoneyController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAcccountProcessDto p)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == p.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();


            p.SenderID = user.Id;
            p.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.ProcessType = "Havale";
            p.ReceiverID = receiverAccountNumberID;

            return RedirectToAction("Index", "Deneme");
        }
    }
}
