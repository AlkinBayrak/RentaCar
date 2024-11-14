using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentAndSell.Car.API.Data.Entities.Concrete;
using RentAndSell.Car.API.Models;
using System.Text;

namespace RentAndSell.Car.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<Kullanici> _userManager;
		private readonly SignInManager<Kullanici> _signInManager;

		public AuthController(UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("Login")]
		public ActionResult Login(LoginViewModel model)
		{
			LoginResultVİewModel loginResult = new LoginResultVİewModel();

			Kullanici? kullanici = _userManager.FindByNameAsync(model.UserName).Result;

			if (kullanici is null)
			{
				loginResult.IsLogin = false;
				loginResult.ErrorMessage = "Kullanıcı veya şifreniz yanlıştır";

				return Ok(loginResult);
			}

			bool passwordChecked = _userManager.CheckPasswordAsync(kullanici, model.Password).Result;

			if (!passwordChecked)
			{
				loginResult.IsLogin = false;
				loginResult.ErrorMessage = "Kullanıcı veya şifreniz yanlıştır";

				return Ok(loginResult);
			}

			var usernamePassword = $"{model.UserName}:{model.Password}";
			var base64EncodeUserNamePassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(usernamePassword));
			var basicAuth = $"Basic {base64EncodeUserNamePassword}";
			
			loginResult.IsLogin = true;
			loginResult.BasicAuth = basicAuth;
			


			return Ok(loginResult);
		}
	}
}
