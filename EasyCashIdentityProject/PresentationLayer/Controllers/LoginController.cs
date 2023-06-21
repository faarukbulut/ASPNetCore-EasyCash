using DtoLayer.Dtos.AppUserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserLoginDto appUserLoginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(appUserLoginDto.Username, appUserLoginDto.Password, false, false);
			
			if(result.Succeeded)
			{
				return RedirectToAction("Index", "MyProfile");
			}

			return View();
		}


	}
}
