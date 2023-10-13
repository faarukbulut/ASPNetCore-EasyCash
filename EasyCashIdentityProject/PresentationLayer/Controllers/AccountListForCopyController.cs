using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class AccountListForCopyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICostumerAccountService _costumerAccountService;

        public AccountListForCopyController(UserManager<AppUser> userManager, ICostumerAccountService costumerAccountService)
        {
            _userManager = userManager;
            _costumerAccountService = costumerAccountService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var context = new Context();
            var values = _costumerAccountService.TGetCustomerAccountsList(user.Id);
            return View(values);
        }
    }
}
