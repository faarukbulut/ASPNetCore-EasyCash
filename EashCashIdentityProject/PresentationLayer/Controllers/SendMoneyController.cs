using BusinessLayer.Abstract;
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
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(String mycurrency)
        {
            ViewBag.currency = mycurrency;


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAcccountProcessDto p)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == p.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();
            var senderAccountNumberID = context.CustomerAccounts.Where(x => x.AppUserID == user.Id).Where(y => y.CustomerAccountCurrency == "TL").Select(z => z.CustomerAccountID).FirstOrDefault();
            var values = new CustomerAccountProcess();

            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = senderAccountNumberID;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = p.Amount;
            values.Description = p.Description;

            _customerAccountProcessService.TInsert(values);


            return RedirectToAction("Index", "Deneme");
        }




    }
}
